using System;

namespace CSFramework.MVVM.Data
{


    public enum SoftLayer
    {
        Dal,
        Bll,
        Ui
    }

    public enum TaskType
    {
       // 一般调用
        General,
        //线程
        Thread,
        //定时器
        Timer
    }

    /// <summary>
    /// 消息等级
    /// </summary>
    [Flags]
    public enum MsgLevel
    {
        Normal =0x1,
        Debug = 0x2,
        Trace = 0x4
    }

    public enum MsgType
    {
        Common = 1,
        System = 2,
        Operation = 3
    }

    public enum RunStatus
    {
        //开始
        Start =0,
        //过程
        Process,
        //结束
        End,
        //任务继续
        Continue
    }


    public enum SysMsgType
    {
        /// <summary>
        /// 系统信息
        /// </summary>
        SysInfo,
        /// <summary>
        /// 系统错误
        /// </summary>
        SysError,
        /// <summary>
        /// 系统警告
        /// </summary>
        SysWarn,
        /// <summary>
        /// 系统调试
        /// </summary>
        SysTest,

    }

   
}
