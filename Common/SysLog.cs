using System;
using System.IO;
using CSFramework.Common.Data;
using CSFramework.MVVM.Data;

namespace CSFramework.Common
{
    internal static class SysLog
    {
        private static readonly SysLogInfo SysLogInfo = SysInfoLoader.FrameworkInfo.SysLogInfo;

        static SysLog()
        {
            if (string.IsNullOrEmpty(SysLogInfo.DstDirPath)) SysLogInfo.DstDirPath = ".\\SysLog";
            if (Directory.Exists(SysLogInfo.DstDirPath)) Directory.CreateDirectory(SysLogInfo.DstDirPath);
        }


        public static void WriteError(TaskInfo task, NotifyInfo notify)
        { 
            try
            {
                var fileFullName = $"{SysLogInfo.DstDirPath}\\{DateTime.Now:yyyyMMdd}.log";
                var sysLog = GetSysDesc(task, notify);

                using (var sw = new StreamWriter(fileFullName, true))
                {
                    sw.Write(sysLog);
                    sw.Close();
                }
            }
            catch
            {
                if (Directory.Exists(SysLogInfo.DstDirPath)) Directory.CreateDirectory(SysLogInfo.DstDirPath);
            }
        }

        private static string GetSysDesc(TaskInfo task, NotifyInfo notify)
        {
            var str = $"任务名称：{task.Name}\r\n发生时间：{notify.DateTime:HH:mm:ss}\r\n消息等级：{notify.MsgLevel}\r\n消息内容：\r\n{ notify.Message}\r\n跟踪栈信息：\r\n{notify.Track}\r\n";
            return str;
        }

       
    }
}
