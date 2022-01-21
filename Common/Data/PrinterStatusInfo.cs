using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.Data
{
    public  class PrinterStatusInfo
    {
        public bool WorkOffline { get; set; }

        public PrinterStatus PrinterStatus { get; set; }

        public ExtendedDetectedErrorState ExtendedDetectedErrorState { get; set; }

        public ExtendedPrinterStatus ExtendedPrinterStatus { get; set; }
    }
}
