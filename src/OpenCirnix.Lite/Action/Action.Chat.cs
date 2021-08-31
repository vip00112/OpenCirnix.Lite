using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;
using static OpenCirnix.Lite.WindowNative;

namespace OpenCirnix.Lite
{
    public static class ChatAction
    {

        private static readonly byte[] MessageSearchPattern = { 0x94, 0x28, 0x49, 0x65, 0x94 };
        private static readonly byte[] MessageAdditionalPattern = { 0x65, 0x9B, 3, 0x36, 0x65 };
        private static readonly byte[] SelectedReceiverPattern = { 0xD3, 0xAF, 0x2A, 0x26, 0xD3 }; // 0x260
        private static readonly byte[] TargetReceiverPattern = { 0xB0, 0x32, 0x5B, 0x2C, 0xB0 }; // 0x2A8

        public static IntPtr CEditBoxOffset = IntPtr.Zero;
        public static IntPtr MessageOffset = IntPtr.Zero;
        public static IntPtr SelectedReceiverOffset = IntPtr.Zero;
        public static IntPtr TargetReceiverOffset = IntPtr.Zero;

        public static string MsgTitleColor = "|CFF33CCFF";
        public static string MsgTitle = "「Cirnix.Lite」";
        public static string MsgColor = "|CFF66FF99";

        public static bool GetOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            CEditBoxOffset = FollowPointer(StormDllOffset + 0x58280, MessageSearchPattern);
            return CEditBoxOffset != IntPtr.Zero;
        }

        public static string GetMessage()
        {
            if (GetOffset())
            {
                byte[] buffer = new byte[0x100];
                if (ReadProcessMemory(Warcraft3Info.Handle, MessageOffset = CEditBoxOffset + 0x88, buffer, 0x100, out _))
                    return ConvertToString(buffer);
            }
            CEditBoxOffset = IntPtr.Zero;
            return null;
        }

        public static string ConvertToString(byte[] buffer)
        {
            int Length = buffer.Length - 1;
            for (int i = 1; i < buffer.Length; i++)
            {
                if (buffer[i] != 0) continue;
                Length = i;
                if (Length == 1 && buffer[0] == 0) return null;
                break;
            }
            byte[] iBuffer = new byte[Length];
            Array.ConstrainedCopy(buffer, 0, iBuffer, 0, Length);
            return Encoding.UTF8.GetString(iBuffer);
        }

        public static bool GetSelectedReceiveStatus()
        {
            SelectedReceiverOffset = FollowPointer(StormDllOffset + 0x5837C, SelectedReceiverPattern);
            if (SelectedReceiverOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset += 0x260, buffer, 4, out _))
                    return true;
            }
            SelectedReceiverOffset = IntPtr.Zero;
            return false;
        }

        public static void ApplyChat()
        {
            if (!States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
            }

            PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
            Thread.Sleep(50);
            if (States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
            }
        }

        public static bool SendMsg(bool useTitle, params string[] args)
        {
            if (args == null || args.Length == 0) return false;
            if (args.Length == 1)
            {
                Thread.Sleep(100);
                return SendInstantMsg(useTitle, args[0]);
            }
            else
            {
                return SendMsg(useTitle, args, 100);
            }
        }

        public static bool SendMsg(bool useTitle, string[] args, int delay)
        {
            if (Warcraft3Info.Process == null) return false;

            foreach (var arg in args)
            {
                if (string.IsNullOrEmpty(arg)) continue;
                if (delay > 0) Thread.Sleep(delay);

                MessageCut((useTitle ? $"\x1{MsgTitleColor}{MsgTitle} {MsgColor}" : string.Empty) + arg);
            }
            return true;
        }

        public static bool SendInstantMsg(bool useTitle, string arg)
        {
            if (Warcraft3Info.Process == null || string.IsNullOrEmpty(arg)) return false;

            MessageCut((useTitle ? $"\x1{MsgTitleColor}{MsgTitle} {MsgColor}" : string.Empty) + arg);
            return true;
        }

        private static void MessageCut(string pMessage)
        {
            if (string.IsNullOrEmpty(pMessage)) return;

            if (CEditBoxOffset == IntPtr.Zero)
            {
                CEditBoxOffset = SearchAddress(MessageAdditionalPattern);
                MessageOffset = CEditBoxOffset + 0x88;
            }
            if (CEditBoxOffset == IntPtr.Zero) return;

            byte[] bytes = Encoding.UTF8.GetBytes(pMessage);

            switch (pMessage[0])
            {
                case '!':
                    States.UserState = CommandTag.Default;
                    bytes[0] = 0;
                    break;
                case '-':
                    States.UserState = CommandTag.Chat;
                    break;
            }

            WriteProcessMemory(Warcraft3Info.Handle, MessageOffset, bytes, bytes.Length + 1, out _);
            if (bytes[0] != 0) ApplyChat();
        }
    }
}
