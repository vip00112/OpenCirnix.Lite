using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCirnix.Lite
{
    [Flags]
    public enum MemProtect : uint
    {
        PAGE_EXECUTE = 0x00000010,
        PAGE_EXECUTE_READ = 0x00000020,
        PAGE_EXECUTE_READWRITE = 0x00000040,
        PAGE_EXECUTE_WRITECOPY = 0x00000080,
        PAGE_NOACCESS = 0x00000001,
        PAGE_READONLY = 0x00000002,
        PAGE_READWRITE = 0x00000004,
        PAGE_WRITECOPY = 0x00000008,
        PAGE_GUARD = 0x00000100,
        PAGE_NOCACHE = 0x00000200,
        PAGE_WRITECOMBINE = 0x00000400
    }

    public enum MemState : uint
    {
        MEM_COMMIT = 0x1000,
        MEM_FREE = 0x10000,
        MEM_RESERVE = 0x2000
    }

    public enum MemType : uint
    {
        MEM_IMAGE = 0x1000000,
        MEM_MAPPED = 0x40000,
        MEM_PRIVATE = 0x20000
    }

    public enum WarcraftState : byte
    {
        None = 0,
        Closed = 1,
        Error = 3,
        OK = 2
    }

    internal enum ChatMode : int
    {
        Private = 0,
        Team = 1,
        Spectator = 2,
        All = 3
    }

    public enum MusicState : byte
    {
        None = 0,
        Offline = 1,
        BattleNet = 2, // 로비, 대기실, 맵로딩중
        InGameDefault = 3, // 게임중
        InGameCustom = 4, // 게임 결과 화면
        Stopped = 5 // 맵 로딩 완료
    }

    public enum CommandTag
    {
        None = 0,   // null
        Default = 1, // !
        Chat = 2, // -
        Cheat = 3   // @
    }

    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }

    public enum ScreenState
    {
        None, InLobbyOrRoom, InWaitRoom, InGame
    }
}
