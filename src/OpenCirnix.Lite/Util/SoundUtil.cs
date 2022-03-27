using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public static class SoundUtil
    {
        public static void Play(byte[] data)
        {
            using (var player = new SoundPlayer())
            using (var ms = new MemoryStream(data))
            {
                player.Stream = ms;
                player.Play();
            }
        }

        public static void Play(UnmanagedMemoryStream ms)
        {
            using (var player = new SoundPlayer())
            {
                player.Stream = ms;
                player.Play();
            }
        }
    }
}
