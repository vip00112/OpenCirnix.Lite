using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenCirnix.Lite.MemoryEditor;
using static OpenCirnix.Lite.WindowNative;

namespace OpenCirnix.Lite
{
    public static class KeyMappingAction
    {
        public static bool IsModifyMode;

        private static List<KeyMapping> _mappings;

        static KeyMappingAction()
        {
            _mappings = new List<KeyMapping>();
        }

        public static bool HasMapping(Keys press)
        {
            var mapped = _mappings.FirstOrDefault(o => o.IsMapped(press));
            return mapped != null;
        }

        public static void AddMapping(Keys press, Keys mapping)
        {
            RemoveMapping(press);
            _mappings.Add(new KeyMapping(press, mapping));
        }

        public static void RemoveMapping(Keys press)
        {
            var mapped = _mappings.FirstOrDefault(o => o.IsMapped(press));
            if (mapped != null) _mappings.Remove(mapped);
        }

        public static List<KeyMapping> GetMappings()
        {
            return _mappings.ToList();
        }

        public static void StartHook()
        {
            KeyboardHooker.HookStart();
        }

        public static void EndHook()
        {
            KeyboardHooker.HookEnd();
        }

        #region Inner Class
        private static class KeyboardHooker
        {
            private const int WM_KEYDOWN = 0x100;

            private static LowLevelKeyboardProc _proc;
            private static IntPtr _hookID;

            static KeyboardHooker()
            {
                _proc = HookCallback;
                _hookID = IntPtr.Zero;
            }

            private static IntPtr HookCallback(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
            {
                if (nCode < 0 || !ForegroundWar3() || States.IsChatBoxOpen || wParam != WM_KEYDOWN || IsModifyMode)
                {
                    return CallNextHookEx(_hookID, nCode, wParam, ref lParam);
                }

                Keys vkCode = lParam.VkCode;
                var mapped = _mappings.FirstOrDefault(o => o.IsMapped(vkCode));
                if (mapped != null)
                {
                    mapped.Action();
                    return (IntPtr) 1;
                }
                return CallNextHookEx(_hookID, nCode, wParam, ref lParam);
            }

            public static void HookStart()
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    _hookID = SetWindowsHookEx(0xD, _proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
            public static void HookEnd()
            {
                UnhookWindowsHookEx(_hookID);
            }
        }
        #endregion
    }

    public class KeyMapping
    {
        public KeyMapping(Keys press, Keys mapping)
        {
            Press = press;
            Mapping = mapping;
        }

        public Keys Press { get; set; }

        public Keys Mapping { get; set; }

        public bool IsMapped(Keys press)
        {
            return press == Press;
        }

        public void Action()
        {
            keybd_event((byte) Mapping, 0, 0, 0x21);
            keybd_event((byte) Mapping, 0, 2, 0x21);
        }

        public static string GetKeyString(Keys key)
        {
            if (key >= Keys.D0 && key <= Keys.D9)
            {
                return key.ToString().Replace("D", "");
            }

            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            {
                return key.ToString().Replace("NumPad", "N");
            }

            switch (key)
            {
                case 0: return "None";

                case Keys.Oemtilde: return "`";
                case Keys.OemMinus: return "-";
                case Keys.Oemplus: return "=";
                case Keys.Oem5: return "\\";
                case Keys.OemOpenBrackets: return "[";
                case Keys.Oem6: return "]";
                case Keys.Oem1: return ";";
                case Keys.Oem7: return "'";
                case Keys.Oemcomma: return ",";
                case Keys.OemPeriod: return ".";
                case Keys.OemQuestion: return "/";

                case Keys.Divide: return "N/";
                case Keys.Multiply: return "N*";
                case Keys.Subtract: return "N-";
                case Keys.Add: return "N+";
                case Keys.Decimal: return "N.";

                case Keys.Left: return "←";
                case Keys.Up: return "↑";
                case Keys.Right: return "→";
                case Keys.Down: return "↓";

                case Keys.PageUp: return "PgUp";
                case Keys.PageDown: return "PgDn";
            }
            return key.ToString();
        }
    }
}
