using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenCirnix.Lite
{
    public class Setting
    {
        private const string FilePath = "setting.json";

        public Setting()
        {
            KeyMappings = new List<KeyMapping>();
            BanedUsers = new List<User>();
        }

        public bool IsWindowMode { get; set; }

        public bool IsViewSpeed { get; set; }

        public bool IsViewManaBer { get; set; }

        public string Path { get; set; }

        public int GameDelay { get; set; }

        public bool IsUseKeyMapping { get; set; } = true;

        public List<KeyMapping> KeyMappings { get; set; }

        public List<User> BanedUsers { get; set; }

        public static void Save(Setting setting)
        {
            string json = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static Setting Load()
        {
            if (!File.Exists(FilePath)) return null;

            string json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json)) return null;

            try
            {
                return JsonConvert.DeserializeObject<Setting>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
