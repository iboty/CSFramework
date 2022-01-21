using CSFramework.MVVM.Data;
using CSFramework.MVVM.Models;

namespace CSFramework.Common.Data
{
    public class DebugInfo : ModelBase
    {
        public string TaskName { get; set; }

        public string NotifyTime { get; set; }

        public string Message { get; set; }

        public string Track { get; set; }

        public MsgLevelDisplay MessageLevel { get; set; }

        public MessageCodeDisplay MessageCode { get; set; }

        public RunStatusDisplay RunStatus { get; set; }
    }

    public enum MsgLevelDisplay
    {
        正常 = 0x01,
        调试 = 0x02,
        追踪 = 0x04
    }

    public enum MessageCodeDisplay
    {
        正常,
        成功,
        错误,
        告警,
        无效,
        询问,
        确定
    }

    public enum RunStatusDisplay
    {
        开始,
        过程,
        结束
    }
}
