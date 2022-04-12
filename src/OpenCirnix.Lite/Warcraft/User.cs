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
            return IsMatchName(findName) || IsMatchIp(findIp);
        }

        private bool IsMatchName(string findName)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(findName)) return false;

            return Name.ToLower() == findName.ToLower();
        }

        private bool IsMatchIp(string findIp)
        {
            if (string.IsNullOrWhiteSpace(Ip) || string.IsNullOrWhiteSpace(findIp)) return false;
            if (Ip == AnyIp || findIp == AnyIp) return false;

            return Ip.Contains(findIp);
        }
    }
}
