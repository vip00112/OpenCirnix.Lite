using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public static class WindowNative
    {
        [DllImport("user32")]
        public static extern void mouse_event
        (
            [In] uint dwFlags,
            [In] uint dx,
            [In] uint dy,
            [In] uint dwData,
            [In] uint dwExtraInfo
        );

        [DllImport("user32")]
        public static extern void keybd_event
        (
            [In] byte bVk,
            [In] byte bScan,
            [In] uint dwFlags,
            [In] uint dwExtraInfo
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage
        (
            [In] IntPtr hWnd,
            [In] uint Msg,
            [In] uint wParam,
            [In] uint lParam
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern int GetCursorPos
        (
            [Out] out POINT point
        );

        [DllImport("user32")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32")]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int hookID, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32", SetLastError = true)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern int GetLastError();

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, out string lpBuffer, int dwSize, IntPtr lpArguments);

        [DllImport("psapi", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EmptyWorkingSet
        (
            [In] IntPtr hWnd
        );

        [DllImport("user32")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr GetWindowRect
        (
            [In] IntPtr hWnd,
            [Out] out RECT rect
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory
        (
            [In] IntPtr hProcess,
            [In] IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            [In] int dwSize,
            [Out] out int lpNumberOfBytesRead
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool VirtualProtectEx
        (
            [In] IntPtr hProcess,
            [In] IntPtr lpAddress,
            [In] int dwSize,
            [In] uint flNewProtect,
            [Out] out uint lpflOldProtect
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WriteProcessMemory
        (
            [In] IntPtr hProcess,
            [In] IntPtr lpBaseAddress,
            [In] byte[] lpBuffer,
            [In] int nSize,
            [Out] out int lpNumberOfBytesWritten
        );

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr OpenProcess
        (
            [In] uint dwDesiredAccess,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
            [In] uint dwProcessId
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle
        (
            [In] IntPtr hObject
        );

        [DllImport("ntdll.dll")]
        internal static extern int NtQueryInformationProcess
        (
            IntPtr processHandle,
            int processInformationClass,
            ref PROCESS_BASIC_INFORMATION ProcessInformation,
            uint processInformationLength,
            IntPtr returnLength
        );

        [DllImport("shell32.dll", SetLastError = true)]
        internal static extern IntPtr CommandLineToArgvW
        (
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine,
            out int pNumArgs
        );

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LocalFree
        (
            IntPtr hMem
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int VirtualQueryEx
        (
            IntPtr hProcess,
            IntPtr lpAddress,
            out MEMORY_BASIC_INFORMATION lpBuffer,
            int dwLength
        );
    }
}
