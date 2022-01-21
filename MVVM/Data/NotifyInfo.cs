using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using CSFramework.Common.Data;
using CSFramework.MVVM.Roles;

namespace CSFramework.MVVM.Data
{
    public class NotifyInfo
    {
        /// <summary>
        /// 任务开始消息初始化
        /// </summary>
        public NotifyInfo()
        {
            MessageCode = MessageCode.Success;
            MessageTheme = "执行开始";
        }

        /// <summary>
        /// 任务结束消息初始化
        /// </summary>
        public NotifyInfo(Exception ex)
        {
            if (ex == null)
            {
                MessageCode = MessageCode.Success;
                return;
            }

            if (ex is WarningException)
            {
                MessageCode = MessageCode.Warn;
            }
            else if (ex is InvalidOperationException)
            {
                MessageCode = MessageCode.Invalid;
            }
            else
            {
                MessageCode = MessageCode.Fault;
            }

            Message = ex.Message;

            if((MsgLevel.Trace & Notifier.MsgLevel) == MsgLevel.Trace) Track = ex.StackTrace;

        }

        /// <summary>
        /// 自定义的消息初始化
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="msgLevel"></param>
        public NotifyInfo(MessageCode messageCode,  string message, object data, MsgLevel msgLevel)
        {
            MessageCode = messageCode;
            Message = message;
            Data = data;
            MsgLevel = msgLevel;
        }

        /// <summary>
        /// 主消息码
        /// </summary>
        public MessageCode MessageCode { get; private set; }
      
        /// <summary>
        /// 消息主题
        /// </summary>
        public string MessageTheme { get; }

        public DateTime MessageTime { get; } = DateTime.Now;

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// 跟踪信息
        /// </summary>
        public string Track { get; }
        /// <summary>
        /// 消息等级
        /// </summary>
        public MsgLevel MsgLevel { get; } = MsgLevel.Normal;
        /// <summary>
        /// 消息附加对象
        /// </summary>
        public object Data { get; }

    }
}
