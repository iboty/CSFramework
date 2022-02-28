using System;

namespace CSFramework.MVVM.Data
{


    public enum SoftLayer
    {
        Dal,
        Bll,
        Ui
    }

    /// <summary>
    /// 执行方式
    /// </summary>
    public enum ExecuteMode
    {
        /// <summary>
        /// 顺序
        /// </summary>
        Order,
        /// <summary>
        ///  异步
        /// </summary>
        Async,
        /// <summary>
        /// 定时器
        /// </summary>
        Timer
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    [Flags]
    public enum MsgLevel
    {
        /// <summary>
        /// 一般信息
        /// </summary>
        Info = 0x01,
        /// <summary>
        /// 警告
        /// </summary>
        Warn = 0x02,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 0x04,
        /// <summary>
        /// 调试
        /// </summary>
        Debug = 0x08,
        /// <summary>
        /// 通知
        /// </summary>
        Notice = 0x10,
        /// <summary>
        /// 跟踪
        /// </summary>
        Trace = 0x20,
        /// <summary>
        /// 严重的错误， 一般指内部系统错误
        /// </summary>
        Fault=  0x40
    }

    public enum ErrorLevel
    {
        Warn = 0x02,

        Error = 0x04
    }

    /// <summary>
    /// 结束后的运行结果 
    /// </summary>
    public enum RunResult
    {
        /// <summary>
        /// 无结果
        /// </summary>
        None,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        Fault
       
    }

  

    public enum RunStatus
    {
        /// <summary>
        /// 正在开始
        /// </summary>
        Starting = 0,

        /// <summary>
        /// 撤销
        /// </summary>
        Cancel,

        /// <summary>
        /// 已经开始
        /// </summary>
        Started,

        /// <summary>
        /// 等待响应
        /// </summary>
        Waiting,

        /// <summary>
        /// 正在结束
        /// </summary>
        Ending,

        /// <summary>
        /// 结束
        /// </summary>
        Ended
    }
}
