using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.Data
{
    public class IpInfo
    {
        public IpInfo()
        {
        }

        public IpInfo(string ipAddr, string macAddr, string gateway,
            string netMask, string dns, bool isNormal)
        {
            IpAddr = ipAddr;
            MacAddr = macAddr;
            Gateway = gateway;
            NetMask = netMask;
            Dns = dns;
            IsNormal = isNormal;
        }

        public string MacAddr { get; set; }

        public string IpAddr { get; set; }
        public string Gateway { get; set; }
        public string NetMask { get; set; }
        public string Dns { get; set; }
        public bool IsNormal { get; set; }
    }
}
