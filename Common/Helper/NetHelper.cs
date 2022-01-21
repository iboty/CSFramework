using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using CSFramework.Common.Data;

namespace CSFramework.Common.Helper
{
    public static class NetHelper
    {
        public static IpInfo GetIpInfo()
        {
            var netObjectArray = NetworkInterface.GetAllNetworkInterfaces();
            if (netObjectArray.Length == 0) return new IpInfo("0.0.0.0", string.Empty,
                "0.0.0.0", "0.0.0.0", "0.0.0.0", false);

            var ipInfoList = new List<IpInfo>();

            foreach (var netObject in netObjectArray)
            {
                if (netObject.NetworkInterfaceType != NetworkInterfaceType.Ethernet &&
                    netObject.NetworkInterfaceType != NetworkInterfaceType.Wireless80211) continue;

                var ipProperties = netObject.GetIPProperties();
                var ipObject =
                    ipProperties.UnicastAddresses.FirstOrDefault(t =>
                        t.Address.AddressFamily == AddressFamily.InterNetwork);

                if (ipObject == null) continue;

                var macAddress = netObject.GetPhysicalAddress();

                //网关
                string gateway = string.Empty;
                GatewayIPAddressInformationCollection gateways = ipProperties.GatewayAddresses;
                foreach (var g in gateways)
                {
                    //如果能够Ping通网关
                    if (IsPingIp(g.Address.ToString()))
                    {
                        //得到网关地址
                        gateway = g.Address.ToString();
                        //跳出循环
                        break;
                    }
                }

                //子网掩码
                string mask = ipObject.IPv4Mask.ToString();

                string dns = ipProperties.DnsAddresses.First().ToString();

                ipInfoList.Add(new IpInfo(ipObject.Address.ToString(), macAddress.ToString(), gateway, mask, dns,
                    netObject.OperationalStatus == OperationalStatus.Up));
            }

            if (ipInfoList.Count == 0) return new IpInfo("0.0.0.0", "0.0.0.0",
                "0.0.0.0", "0.0.0.0", string.Empty, false);
            var ipInfo = ipInfoList.FirstOrDefault(t => t.IsNormal);

            return ipInfo ?? ipInfoList.First();
        }

        /// <summary>
        /// 尝试Ping指定IP是否能够Ping通
        /// </summary>
        /// <param name="ip">指定IP</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsPingIp(string ip)
        {
            try
            {
                //创建Ping对象
                Ping ping = new Ping();
                //接受Ping返回值
                ping.Send(ip, 1000);
                //Ping通
                return true;
            }
            catch
            {
                //Ping失败
                return false;
            }
        }

        /// <summary>
        /// 设置IP地址，掩码，网关和DNS
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="netMask"></param>
        /// <param name="gateway"></param>
        /// <param name="dns"></param>
        public static void SetIpAddress(string ip, string netMask, string gateway, string dns)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                //如果没有启用IP设置的网络设备则跳过
                if (!(bool)mo["IPEnabled"])
                    continue;

                //设置IP地址和掩码
                ManagementBaseObject inPar;
                if (!string.IsNullOrEmpty(ip))
                {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = new[] { ip };
                    inPar["SubnetMask"] = new[] { netMask };
                    mo.InvokeMethod("EnableStatic", inPar, null);
                }

                //设置网关地址
                if (!string.IsNullOrEmpty(gateway))
                {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = new[] { gateway };
                    mo.InvokeMethod("SetGateways", inPar, null);
                }

                //设置DNS地址
                if (!string.IsNullOrEmpty(dns))
                {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = new[] { dns };
                    mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
            }
        }
    }
}
