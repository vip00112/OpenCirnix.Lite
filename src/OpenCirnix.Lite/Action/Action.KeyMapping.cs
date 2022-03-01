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
        private Keys _press;
        private Keys _mapping;

        public KeyMapping(Keys press, Keys mapping)
        {
            _press = press;
            _mapping = mapping;
        }

        public bool IsMapped(Keys press)
        {
            return press == _press;
        }

        public void Action()
        {
            keybd_event((byte) _mapping, 0, 0, 0x21);
            keybd_event((byte) _mapping, 0, 2, 0x21);
        }
    }
}
