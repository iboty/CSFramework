using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Drive
{
    public  class FsDriver
    {
        public string DriveName { get; private set; }
        private IntPtr _handelIntPtr;


        public  void Open(string driveName = null)
        {
            if (!string.IsNullOrEmpty(driveName)) DriveName = driveName;

            _handelIntPtr = WinDriveApi.CreateFile($"\\\\.\\{driveName}", FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open,
                FileOptions.None, IntPtr.Zero);

            if (_handelIntPtr == IntPtr.Zero) throw new Exception($"打开驱动{DriveName}失败");
        }

        public void Close()
        {
            if(_handelIntPtr == IntPtr.Zero) return;

            WinDriveApi.CloseHandle(_handelIntPtr);
            _handelIntPtr = IntPtr.Zero;
        }

        public byte[] Command(uint ctlCode , byte[] writeBytes, uint initReadLen = 0)
        {
            if (_handelIntPtr == IntPtr.Zero) throw new Exception($"驱动{DriveName} 未启动");

            var  readBytes = initReadLen == 0? null : new byte[initReadLen];
            uint retBytesLen = 0;

            var result =  WinDriveApi.DeviceIoControl(_handelIntPtr, ctlCode, writeBytes, GetBytesLen(writeBytes), readBytes, initReadLen, ref retBytesLen, 0);

            if (!result) throw new Exception($"{DriveName}驱动控制{ctlCode} 发生错误");

            if (readBytes == null) return null;

            if (retBytesLen < initReadLen) readBytes = readBytes.Take((int)retBytesLen).ToArray();

            return readBytes;
        }

        public T2 Command<T1,T2>(uint ctlCode, T1 writeStruct) where T1 : struct where T2 : struct
        {
            if (_handelIntPtr == IntPtr.Zero) throw new Exception($"驱动{DriveName} 未启动");

            var writeLen = Marshal.SizeOf(typeof(T1));
            var readLen = Marshal.SizeOf(typeof(T2));
            uint retBytesLen = 0;

            var writeIntPtr = Marshal.AllocHGlobal(writeLen);
            Marshal.StructureToPtr(writeStruct, writeIntPtr,true);

            var readIntPtr = Marshal.AllocHGlobal(readLen);

            var result = WinDriveApi.DeviceIoControl(_handelIntPtr, ctlCode, writeIntPtr, (uint)writeLen, readIntPtr, (uint)readLen, ref retBytesLen, 0);

            if (!result) throw new Exception($"{DriveName}驱动控制{ctlCode} 发生错误");

            var readStruct = (T2)Marshal.PtrToStructure(readIntPtr, typeof(T2));

           return readStruct;
        }

        public T Command<T>(uint ctlCode, T dataStruct) where T : struct 
        {
            if(_handelIntPtr == IntPtr.Zero) throw  new Exception($"驱动{DriveName} 未启动");

            var dataLen = Marshal.SizeOf(dataStruct);
          

            uint retBytesLen = 0;

            var dataIntPtr = Marshal.AllocHGlobal(dataLen);
            Marshal.StructureToPtr(dataStruct, dataIntPtr, true);

            var result = WinDriveApi.DeviceIoControl(_handelIntPtr, ctlCode, dataIntPtr, (uint)dataLen, dataIntPtr, (uint)dataLen, ref retBytesLen, 0);

            if (!result) throw new Exception($"{DriveName}驱动控制{ctlCode} 发生错误");

            var readStruct = (T)Marshal.PtrToStructure(dataIntPtr, typeof(T));

            return readStruct;
        }


        private uint GetBytesLen(byte[] dataBytes)
        {
            return (uint)(dataBytes?.Length ?? 0);
        }
    }
}
