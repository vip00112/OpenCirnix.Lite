using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;
using static OpenCirnix.Lite.WindowNative;

namespace OpenCirnix.Lite
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PROCESS_BASIC_INFORMATION
    {
        internal int ExitProcess;
        internal IntPtr PebBaseAddress;
        internal UIntPtr AffinityMask;
        internal int BasePriority;
        internal UIntPtr UniqueProcessId;
        internal UIntPtr InheritedFromUniqueProcessId;

        internal uint Size => (uint) Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION));
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UNICODE_STRING
    {
        internal ushort Length;
        internal ushort MaximumLength;
        internal IntPtr buffer;
    }

    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public MemProtect AllocationProtect;
        public IntPtr RegionSize;
        public MemState State;
        public MemProtect Protect;
        public MemType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X, Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Point(POINT p) => new Point(p.X, p.Y);

        public static implicit operator POINT(Point p) => new POINT(p.X, p.Y);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left, Top, Right, Bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

        public int X
        {
            get => Left;
            set
            {
                Right -= Left - value;
                Left = value;
            }
        }

        public int Y
        {
            get => Top;
            set
            {
                Bottom -= Top - value;
                Top = value;
            }
        }

        public int Height
        {
            get => Bottom - Top;
            set => Bottom = value + Top;
        }

        public int Width
        {
            get => Right - Left;
            set => Right = value + Left;
        }

        public Point Location
        {
            get => new Point(Left, Top);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public static implicit operator Rectangle(RECT r) => new Rectangle(r.Left, r.Top, r.Width, r.Height);

        public static implicit operator RECT(Rectangle r) => new RECT(r);

        public static bool operator ==(RECT r1, RECT r2) => r1.Equals(r2);

        public static bool operator !=(RECT r1, RECT r2) => !r1.Equals(r2);

        public bool Equals(RECT r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

        public override bool Equals(object obj)
        {
            if (obj is RECT)
                return Equals((RECT) obj);
            else if (obj is Rectangle)
                return Equals(new RECT((Rectangle) obj));
            return false;
        }

        public override int GetHashCode() => ((Rectangle) this).GetHashCode();

        public override string ToString()
            => $"{{Left={Left},Top={Top},Right={Right},Bottom={Bottom}}}";
    }

    public struct WarcraftInfo
    {
        private Process _process;

        public uint ID { get { return (uint) (_process?.Id ?? 0); } }

        public IntPtr BaseAddress { get { return _process?.MainModule.BaseAddress ?? IntPtr.Zero; } }

        public IntPtr MainWindowHandle { get { return _process?.MainWindowHandle ?? IntPtr.Zero; } }

        public IntPtr Handle { get; private set; }

        public Process Process
        {
            get => _process;
            set
            {
                if (value?.Id == _process?.Id) return;
                Reset();
                if (value != null
                 && value.MainModule.FileVersionInfo.FileVersion == "1.28.5.7680"
                 && value.MainWindowHandle != IntPtr.Zero)
                {
                    try
                    {
                        Handle = OpenProcess(0x38, false, (uint) value.Id);
                        if (Handle == IntPtr.Zero) return;

                        value.EnableRaisingEvents = true;
                        value.Exited += (sender, e) => new Action(Reset)();
                        _process = value;
                    }
                    catch
                    {
                        if (Handle != IntPtr.Zero)
                        {
                            CloseHandle(Handle);
                            Handle = IntPtr.Zero;
                        }
                    }
                }
            }
        }

        public bool HasExited
        {
            get
            {
                if (_process == null)
                    return true;
                try
                {
                    return _process.HasExited;
                }
                catch
                {
                    return true;
                }
            }
        }

        public void Refresh()
        {
            if (_process == null) return;
            _process.Refresh();
        }

        public bool Close()
        {
            try
            {
                _process?.Kill();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Reset();
            }
        }

        public void Reset()
        {
            if (_process != null)
            {
                if (Handle != IntPtr.Zero)
                {
                    CloseHandle(Handle);
                    Handle = IntPtr.Zero;
                }
                _process.Close();
                _process = null;
            }

            GameDllOffset = IntPtr.Zero;
            StormDllOffset = IntPtr.Zero;
            GameDelayAction.Offset = IntPtr.Zero;
            ChatAction.CEditBoxOffset = IntPtr.Zero;
            ChatAction.MessageOffset = IntPtr.Zero;
            ChatAction.SelectedReceiverOffset = IntPtr.Zero;
            ChatAction.TargetReceiverOffset = IntPtr.Zero;
            States.OsTcpOffset = IntPtr.Zero;
        }
    }
}
