using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Drive
{
    public static class WinDriveApi
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(string fileName, FileAccess access, FileShare sharing, IntPtr securityAttributes, FileMode mode, FileOptions options, IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(IntPtr device, uint ctlCode,  byte[] inBuffer, uint inBufferSize, byte[] outBuffer, uint outBufferSize, ref uint bytesReturned, uint overLapped);

        [DllImport("kernel32.dll")]
        public static extern void CloseHandle(IntPtr hdl);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(IntPtr device, uint ctlCode, IntPtr inBuffer, uint inBufferSize, IntPtr outBuffer, uint outBufferSize, ref uint bytesReturned, uint overLapped);
    }
}
