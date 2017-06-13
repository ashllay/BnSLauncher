using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BnS_Launcher.Slider
{
    public class Memory : IDisposable
    {
        private System.Diagnostics.Process process;
        private IntPtr processHandle;
        private bool isDisposed;
        public const string OffsetPattern = "(\\+|\\-){0,1}(0x){0,1}[a-fA-F0-9]{1,}";

        public System.Diagnostics.Process Process
        {
            get
            {
                return process;
            }
        }

        public Memory(System.Diagnostics.Process process)
        {
            if (process == null)
            {
                throw new ArgumentNullException("process");
            }
            this.process = process;
            processHandle = Win32.OpenProcess(
                Win32.ProcessAccessType.PROCESS_VM_OPERATION | 
                Win32.ProcessAccessType.PROCESS_VM_READ | 
                Win32.ProcessAccessType.PROCESS_VM_WRITE, true, (uint)process.Id);
            if (processHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Could not open the process");
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }
            Win32.CloseHandle(processHandle);
            process = null;
            processHandle = IntPtr.Zero;
            isDisposed = true;
        }

        ~Memory()
        {
            Dispose(false);
        }

        public ProcessModule FindModule(string name)
        {
            ProcessModule processModule;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            IEnumerator enumerator = process.Modules.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ProcessModule current = (ProcessModule)enumerator.Current;
                    if (current.ModuleName.ToLower() != name.ToLower())
                    {
                        continue;
                    }
                    processModule = current;
                    return processModule;
                }
                return null;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return processModule;
        }

        public IntPtr GetAddress(string moduleName, IntPtr baseAddress, int[] offsets)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentNullException("moduleName");
            }
            ProcessModule processModule = FindModule(moduleName);
            if (processModule == null)
            {
                return IntPtr.Zero;
            }
            IntPtr intPtr = processModule.BaseAddress;
            int num = intPtr.ToInt32() + baseAddress.ToInt32();
            return GetAddress((IntPtr)num, offsets);
        }

        public IntPtr GetAddress(IntPtr baseAddress, int[] offsets)
        {
            if (baseAddress == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid base address");
            }
            int num = baseAddress.ToInt32();
            if (offsets != null && offsets.Length != 0)
            {
                byte[] numArray = new byte[4];
                int[] numArray1 = offsets;
                for (int i = 0; i < (int)numArray1.Length; i++)
                {
                    int num1 = numArray1[i];
                    num = ReadInt32((IntPtr)num) + num1;
                }
            }
            return (IntPtr)num;
        }

        public IntPtr GetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException("address");
            }
            string str = null;
            int num = address.IndexOf('\"');
            if (num != -1)
            {
                int num1 = address.IndexOf('\"', num + 1);
                if (num1 == -1)
                {
                    throw new ArgumentException("Invalid module name. Could not find matching \"");
                }
                str = address.Substring(num + 1, num1 - 1);
                address = address.Substring(num1 + 1);
            }
            int[] addressOffsets = Memory.GetAddressOffsets(address);
            int[] numArray = null;
            IntPtr intPtr = (addressOffsets == null || addressOffsets.Length == 0 ? IntPtr.Zero : (IntPtr)addressOffsets[0]);
            if (addressOffsets != null && (int)addressOffsets.Length > 1)
            {
                numArray = new int[(int)addressOffsets.Length - 1];
                for (int i = 0; i < (int)addressOffsets.Length - 1; i++)
                {
                    numArray[i] = addressOffsets[i + 1];
                }
            }
            if (str == null)
            {
                return GetAddress(intPtr, numArray);
            }
            return GetAddress(str, intPtr, numArray);
        }

        protected static int[] GetAddressOffsets(string address)
        {
            string str;
            if (string.IsNullOrEmpty(address))
            {
                return new int[0];
            }
            MatchCollection matchCollections = Regex.Matches(address, "(\\+|\\-){0,1}(0x){0,1}[a-fA-F0-9]{1,}");
            int[] num = new int[matchCollections.Count];
            for (int i = 0; i < matchCollections.Count; i++)
            {
                char value = matchCollections[i].Value[0];
                str = (value == '+' || value == '-' ? matchCollections[i].Value.Substring(1) : matchCollections[i].Value);
                num[i] = Convert.ToInt32(str, 16);
                if (value == '-')
                {
                    num[i] = -num[i];
                }
            }
            return num;
        }

        public double ReadDouble(IntPtr address)
        {
            byte[] numArray = new byte[8];
            ReadMemory(address, numArray, 8);
            return BitConverter.ToDouble(numArray, 0);
        }

        public float ReadFloat(IntPtr address)
        {
            byte[] numArray = new byte[4];
            ReadMemory(address, numArray, 4);
            return BitConverter.ToSingle(numArray, 0);
        }

        public int ReadInt32(IntPtr address)
        {
            byte[] numArray = new byte[4];
            ReadMemory(address, numArray, 4);
            return BitConverter.ToInt32(numArray, 0);
        }

        public void ReadMemory(IntPtr address, byte[] buffer, int size)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Memory");
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero");
            }
            if (address == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid address");
            }
            uint num = 0;
            if (!Win32.ReadProcessMemory(this.processHandle, address, buffer, (uint)size, ref num) || (long)num != (long)size)
            {
                throw new AccessViolationException();
            }
        }

        public uint ReadUInt32(IntPtr address)
        {
            byte[] numArray = new byte[4];
            ReadMemory(address, numArray, 4);
            return BitConverter.ToUInt32(numArray, 0);
        }

        public void WriteDouble(IntPtr address, double value)
        {
            WriteMemory(address, BitConverter.GetBytes(value), 8);
        }

        public void WriteFloat(IntPtr address, float value)
        {
            WriteMemory(address, BitConverter.GetBytes(value), 4);
        }

        public void WriteInt32(IntPtr address, int value)
        {
            WriteMemory(address, BitConverter.GetBytes(value), 4);
        }

        public void WriteMemory(IntPtr address, byte[] buffer, int size)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Memory");
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero");
            }
            if (address == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid address");
            }
            uint num = 0;
            if (!Win32.WriteProcessMemory(this.processHandle, address, buffer, (uint)size, ref num) || (long)num != (long)size)
            {
                throw new AccessViolationException();
            }
        }

        public void WriteUInt32(IntPtr address, uint value)
        {
            WriteMemory(address, BitConverter.GetBytes(value), 4);
        }
    }
}
