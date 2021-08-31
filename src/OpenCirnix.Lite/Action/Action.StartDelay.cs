using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;

namespace OpenCirnix.Lite
{
    public static class StartDelayAction
    {
        public static float StartDelay
        {
            get
            {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0x324146, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set
            {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0x324146, BitConverter.GetBytes(value));
            }
        }
    }
}
