using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using CSFramework.Common.Data;

namespace CSFramework.Common.Helper
{
    public  class PrinterHelper
    {

        public static PrinterStatusInfo GetStatusInfo(string printName)
        {
            var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_Printer WHERE Name = '{printName}'");
            var printer = searcher.Get().OfType<ManagementObject>().FirstOrDefault();
            if (printer == null) return null;
            var info = ComConvert.ManagementObjectToEntity<PrinterStatusInfo>(printer);
            return info;
        }
    }
}
