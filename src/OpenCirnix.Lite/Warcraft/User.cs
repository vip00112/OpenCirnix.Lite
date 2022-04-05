using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenCirnix.Lite
{
    public class User
    {
        public const string AnyIp = "0.0.0.0";

        public string Name { get; set; }

        public string Ip { get; set; }

        public string Reason { get; set; }

        public bool IsMatch(string findName, string findIp)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(findName)) return false;
            if (Name.ToLower() == findName.ToLower()) return true;

            if (string.IsNullOrWhiteSpace(Ip) || string.IsNullOrWhiteSpace(findIp)) return false;
            if (Ip == AnyIp || findIp == AnyIp) return false;
            if (Ip.Contains(findIp)) return true;

            return false;
        }
    }
}
