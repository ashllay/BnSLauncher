﻿using System;
using System.Runtime.InteropServices;

namespace BnS_Launcher.Slider
{
    public static class Win32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int CloseHandle(IntPtr objectHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern IntPtr OpenProcess(Win32.ProcessAccessType access, bool inheritHandler, uint processId);

        [DllImport("Kernel32.dll", CharSet = CharSet.None, ExactSpelling = false, SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, uint size, ref uint read);

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out Win32.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false, SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, uint size, ref uint written);

        public enum AllocationProtect : uint
        {
            PAGE_NOACCESS = 1,
            PAGE_READONLY = 2,
            PAGE_READWRITE = 4,
            PAGE_WRITECOPY = 8,
            PAGE_EXECUTE = 16,
            PAGE_EXECUTE_READ = 32,
            PAGE_EXECUTE_READWRITE = 64,
            PAGE_EXECUTE_WRITECOPY = 128,
            PAGE_GUARD = 256,
            PAGE_NOCACHE = 512,
            PAGE_WRITECOMBINE = 1024
        }

        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;

            public IntPtr AllocationBase;

            public uint AllocationProtect;

            public IntPtr RegionSize;

            public uint State;

            public uint Protect;

            public uint Type;
        }

        [Flags]
        public enum ProcessAccessType
        {
            PROCESS_TERMINATE = 1,
            PROCESS_CREATE_THREAD = 2,
            PROCESS_SET_SESSIONID = 4,
            PROCESS_VM_OPERATION = 8,
            PROCESS_VM_READ = 16,
            PROCESS_VM_WRITE = 32,
            PROCESS_DUP_HANDLE = 64,
            PROCESS_CREATE_PROCESS = 128,
            PROCESS_SET_QUOTA = 256,
            PROCESS_SET_INFORMATION = 512,
            PROCESS_QUERY_INFORMATION = 1024
        }
    }
}
