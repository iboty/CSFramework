using System;
using CSFramework.Common.Data;
using CSFramework.MVVM.Data;

namespace CSFramework.MVVM.Roles
{
    /// <summary>
    ///  通知者
    /// </summary>
    public static class Notifier
    {
        public static event Action<TaskInfo, NotifyInfo> NotifyMsg;

        public static MsgLevel MsgLevel = MsgLevel.Normal;


        internal  static void OnNotifyMsg(TaskInfo taskInfo, NotifyInfo notifyInfo)
        {
            try
            {
                if ((notifyInfo.MsgLevel & MsgLevel) != notifyInfo.MsgLevel) return;

                NotifyMsg?.Invoke(taskInfo, notifyInfo);
            
                taskInfo?.RegArgs?.TaskEvent?.Invoke(taskInfo, notifyInfo);
            }
            catch 
            {
               // throw new CustomException(SysMsgType.SysError,"订阅方法异常", ex.Message);
            }
        }

        /// <summary>
        /// 收集自定义信息
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="msgCode"></param>
        /// <param name="msg"></param>
        /// <param name="msgLevel"></param>
        public static void CollectCustomMsg(string taskName, MessageCode msgCode, string msg, MsgLevel msgLevel = MsgLevel.Normal)
        {
            var taskInfo  = new TaskInfo(taskName);
            var notifyInfo = new NotifyInfo(msgCode,  msg, null, msgLevel);
            OnNotifyMsg(taskInfo, notifyInfo);
        }

        public static void CollectTaskMsg(MessageCode msgCode, string msg, MsgLevel msgLevel = MsgLevel.Normal)
        {
            var taskInfo = Watcher.CurrentTask;
            var notifyInfo = new NotifyInfo(msgCode, msg, null, msgLevel);
            OnNotifyMsg(taskInfo, notifyInfo);
        }

        /// <summary>
        /// 收集自定义信息
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="msgCode"></param>
        /// <param name="msg"></param>
        /// <param name="msgLevel"></param>
        public static void CollectTaskMsg(TaskInfo taskInfo, MessageCode msgCode, string msg, MsgLevel msgLevel = MsgLevel.Normal)
        {
            var notifyInfo = new NotifyInfo(msgCode, msg, null, msgLevel);
            OnNotifyMsg(taskInfo, notifyInfo);
        }
    }
}
