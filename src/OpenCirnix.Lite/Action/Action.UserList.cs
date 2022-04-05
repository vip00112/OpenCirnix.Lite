using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;
using static OpenCirnix.Lite.WindowNative;

namespace OpenCirnix.Lite
{
    public static class UserListAction
	{
		private static readonly byte[] SearchPattern = { 0x1B, 0xA3, 0x1E, 0x0F, 0x1B };
		internal static IntPtr Offset = IntPtr.Zero;
		public static List<User> BanedUsers;

		static UserListAction()
        {
			BanedUsers = new List<User>();
		}

		private static bool GetOffset()
		{
			return (Offset = FollowPointer(StormDllOffset + 0x5809C, SearchPattern)) != IntPtr.Zero;
		}

		public static List<User> FindUserList()
		{
			var users = new List<User>();
			byte[] buffer = new byte[3000];
			if (GetOffset())
			{
				ReadProcessMemory(Warcraft3Info.Handle, Offset, buffer, buffer.Length, out _);
				List<byte[]> list = CheckArea(buffer);
				foreach (byte[] array in list)
				{
					byte[] ipAddr = new byte[4];
					Array.Copy(array, 92, ipAddr, 0, 4);
					var ip = new IPAddress(ipAddr);
					users.Add(new User() { Name = StringFromArray(array, 125), Ip = ip.ToString() });
				}
			}
			return users;
		}

		private static string StringFromArray(byte[] Data, int Offset)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				char c = (char) Data[Offset++];
				if (c == '\0') break;
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		private static List<byte[]> CheckArea(byte[] tmp)
		{
			List<byte[]> list = new List<byte[]>();
			for (int i = 0; i < tmp.Length - 3; i++)
			{
				if (tmp[i] == 255 && tmp[i + 1] == 255 && tmp[i + 2] == 255 && tmp[i + 3] == 255)
				{
					byte[] array = new byte[142];
					Array.Copy(tmp, i, array, 0, 142);
					list.Add(array);
					i += 142;
				}
			}
			return list;
		}
	}
}
