using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OpenCirnix.Lite.WindowNative;

namespace OpenCirnix.Lite
{
    public static class MemoryEditor
    {
        public static WarcraftInfo Warcraft3Info;
        public static IntPtr GameDllOffset = IntPtr.Zero;
        public static IntPtr StormDllOffset = IntPtr.Zero;
        public static bool IsWindows10 = Environment.OSVersion.Version.Major == 10;

        /// <summary>
        /// 메모리 정리 전 / 정리 직후 / 정리 5초후
        /// </summary>
        public static long[] MemoryValue = new long[3];

        public static void DirectPatch(IntPtr offset, params byte[] buffer) => WriteProcessMemory(Warcraft3Info.Handle, offset, buffer, buffer.Length, out _);

        public static void Patch(IntPtr offset, params byte[] buffer) => Patch(offset, buffer.Length, buffer);

        public static void Patch(IntPtr offset, int size, params byte[] buffer)
        {
            VirtualProtectEx(Warcraft3Info.Handle, offset, size, 0x40, out uint lpflOldProtect);
            WriteProcessMemory(Warcraft3Info.Handle, offset, buffer, size, out _);
            VirtualProtectEx(Warcraft3Info.Handle, offset, size, lpflOldProtect, out _);
        }

        public static bool DirectBring(IntPtr offset, int size, out byte[] buffer)
        {
            buffer = new byte[size];
            bool ret = ReadProcessMemory(Warcraft3Info.Handle, offset, buffer, size, out _);
            if (!ret) buffer = null;
            return ret;
        }

        public static byte[] Bring(IntPtr Offset, int size)
        {
            byte[] lpBuffer = new byte[size];
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, 0x40, out uint lpflOldProtect);
            bool ret = ReadProcessMemory(Warcraft3Info.Handle, Offset, lpBuffer, size, out _);
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, lpflOldProtect, out _);
            return ret ? lpBuffer : null;
        }

        public static bool CompareArrays(byte[] a, byte[] b, int num)
        {
            for (int i = 0; i < num; i++)
                try
                {
                    if (a[i] != b[i])
                        return false;
                }
                catch
                {
                    return false;
                }
            return true;
        }

        public static IntPtr SearchAddress(byte[] search, uint maxAdd, int offset, uint interval = 0x10000)
        {
            byte[] lpBuffer = new byte[search.Length];
            for (uint num = 0x10000; num <= maxAdd; num += interval)
            {
                IntPtr lpBaseAddress = new IntPtr(num + offset);
                if (ReadProcessMemory(Warcraft3Info.Handle, lpBaseAddress, lpBuffer, search.Length, out int innerNum) && CompareArrays(search, lpBuffer, innerNum))
                    return lpBaseAddress;
            }
            return IntPtr.Zero;
        }

        public static IntPtr SearchMemoryRegion(byte[] signature, int offset = 4, uint maxAdd = 0x70000000)
        {
            IntPtr lpBaseAddress = IntPtr.Zero;
            byte[] buffer = new byte[signature.Length];
            while (lpBaseAddress.ToInt32() < maxAdd)
            {
                VirtualQueryEx(Warcraft3Info.Handle, lpBaseAddress, out MEMORY_BASIC_INFORMATION info, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                if (info.State == MemState.MEM_COMMIT && (uint) info.Protect < 0x100)
                {
                    IntPtr lpAddress = lpBaseAddress + offset;
                    if (ReadProcessMemory(Warcraft3Info.Handle, lpAddress, buffer, signature.Length, out _) && buffer.SequenceEqual(signature))
                        return lpAddress;
                }
                lpBaseAddress += info.RegionSize.ToInt32();
            }
            return IntPtr.Zero;
        }

        public static IntPtr SearchAddress(byte[] search, int offset = 4)
        {
            if (IsWindows10)
                return SearchMemoryRegion(search, offset);
            else
                return SearchAddress(search, 0x7FFFFFFF, offset);
        }

        public static IntPtr FollowPointer(IntPtr offset, params byte[] signature)
        {
            int length = signature.Length;
            byte[] buffer = Bring(offset, 4);
            if (buffer == null) return IntPtr.Zero;
            offset = new IntPtr(buffer.ToInt32());
            while (true)
            {
                buffer = Bring(offset, 4 + length);
                if (buffer == null) return IntPtr.Zero;
                if (CompareArrays(buffer.SubArray(4), signature, length))
                    return offset;
                int newOffset = buffer.ToInt32();
                if (newOffset == 0) return IntPtr.Zero;
                offset = new IntPtr(newOffset);
            }
        }

        public static IntPtr FollowPointer(IntPtr offset)
        {
            byte[] buffer = Bring(offset, 4);
            if (buffer == null) return IntPtr.Zero;
            return new IntPtr(buffer.ToInt32());
        }

        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }

        public static string GetCommandLine(uint processId)
        {
            IntPtr proc = OpenProcess(0x410, false, processId);
            if (proc == IntPtr.Zero) return null;
            try
            {
                PROCESS_BASIC_INFORMATION pbi = new PROCESS_BASIC_INFORMATION();
                if (NtQueryInformationProcess(proc, 0, ref pbi, pbi.Size, IntPtr.Zero) == 0)
                {
                    byte[] rupp = new byte[IntPtr.Size];
                    if (ReadProcessMemory(proc, (IntPtr) (pbi.PebBaseAddress.ToInt32() + 0x10), rupp, IntPtr.Size, out _))
                    {
                        int ruppPtr = BitConverter.ToInt32(rupp, 0);
                        byte[] cmdl = new byte[Marshal.SizeOf(typeof(UNICODE_STRING))];

                        if (ReadProcessMemory(proc, (IntPtr) (ruppPtr + 0x40), cmdl, Marshal.SizeOf(typeof(UNICODE_STRING)), out _))
                        {
                            UNICODE_STRING ucsData = ByteArrayToStructure<UNICODE_STRING>(cmdl);
                            byte[] parms = new byte[ucsData.Length];
                            if (ReadProcessMemory(proc, ucsData.buffer, parms, ucsData.Length, out _))
                                return Encoding.Unicode.GetString(parms);
                        }
                    }
                }
            }
            finally
            {
                CloseHandle(proc);
            }
            return null;
        }

        public static string[] GetArguments(uint processId)
        {
            string CommandLine = GetCommandLine(processId);
            if (CommandLine == null) return null;
            List<string> args = new List<string>(SplitArgs(CommandLine));
            args.RemoveAt(0);
            return args.ToArray();
        }

        private static string[] SplitArgs(string unsplitArgumentLine)
        {
            IntPtr ptrToSplitArgs = CommandLineToArgvW(unsplitArgumentLine, out int numberOfArgs);

            if (ptrToSplitArgs == IntPtr.Zero) throw new ArgumentException("Unable to split argument.", new Win32Exception());

            try
            {
                string[] splitArgs = new string[numberOfArgs];
                for (int i = 0; i < numberOfArgs; i++)
                    splitArgs[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(ptrToSplitArgs, i * IntPtr.Size));

                return splitArgs;
            }
            finally
            {
                LocalFree(ptrToSplitArgs);
            }
        }

        public static bool ForegroundWar3()
        {
            if (Warcraft3Info.Process == null) return false;
            return Warcraft3Info.MainWindowHandle == GetForegroundWindow();
        }

        /// <summary>
        /// 지정된 프로세스의 사용하지 않는 WorkingSet 메모리를 OS에게 반환하도록 합니다.
        /// </summary>
        /// <param name="process">메모리 해제를 할 프로세스</param>
        /// <returns>메모리 해제 여부</returns>
        public static async Task<bool> TrimProcessMemory(Process process, int ResultDelay, bool NeedResult = false)
        {
            if (process == null) return false;
            bool _result;
            try
            {
                process.Refresh();
                long oldWorkingSet64 = process.WorkingSet64;
                _result = EmptyWorkingSet(process.Handle);
                if (_result && NeedResult)
                {
                    MemoryValue[0] = oldWorkingSet64;
                    process.Refresh();
                    MemoryValue[1] = process.WorkingSet64;
                    if (ResultDelay > 0)
                    {
                        await Task.Delay(ResultDelay);
                        process.Refresh();
                        MemoryValue[2] = process.WorkingSet64;
                    }
                    else
                        MemoryValue[2] = MemoryValue[1];
                }
            }
            catch
            {
                _result = false;
            }

            return _result;
        }

        public static async Task<bool> TrimProcessMemory(bool NeedResult = false)
            => await TrimProcessMemory(Warcraft3Info.Process, 5000, NeedResult);

        public static async Task<bool> TrimProcessMemory(int ResultDelay)
            => await TrimProcessMemory(Warcraft3Info.Process, ResultDelay * 1000, true);
    }
}