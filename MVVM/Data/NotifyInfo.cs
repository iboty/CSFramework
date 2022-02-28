using System;
using System.ComponentModel;
using CSFramework.Common.Data;
using CSFramework.MVVM.Roles;

namespace CSFramework.MVVM.Data
{
    public class NotifyInfo
    {
        /// <summary>
        /// 消息广播ID，用于筛选特定的广播消息
        /// </summary>
        public int BroadcastId { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; internal set; }
        /// <summary>
        /// 跟踪信息
        /// </summary>
        public string Track { get; internal set; }
        /// <summary>
        /// 消息等级
        /// </summary>
        public MsgLevel MsgLevel { get; internal set; } = MsgLevel.Info;

        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime DateTime { get; private set; } = DateTime.Now; 
    }
}
