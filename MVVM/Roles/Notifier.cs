using System;
using CSFramework.Common;
using CSFramework.MVVM.Data;

namespace CSFramework.MVVM.Roles
{
    /// <summary>
    ///  通知者
    /// </summary>
    public static class Notifier
    {
        public static event Action<TaskInfo, NotifyInfo> NotifyMsgEvent;

        public static event Action<TaskInfo, NotifyInfo> NotifySysErrorMsgEvent;

        public static MsgLevel MsgLevel = MsgLevel.Info| MsgLevel.Error | MsgLevel.Warn;

        internal  static void OnNotifyMsg(TaskInfo task, NotifyInfo notify)
        {
            try
            {
                if ((notify.MsgLevel & MsgLevel) != notify.MsgLevel) return;
                if(NotifyMsgEvent == null) return;

                NotifyMsgEvent.Invoke(task, notify);
            }
            catch(Exception ex)
            {
                SysErrorMsg(task, ex);
            }
        }

        public static void SysErrorMsg(TaskInfo task, Exception ex)
        {
            var notify = new NotifyInfo()
            {
                Message = ex.Message,
                MsgLevel = MsgLevel.Fault,
                Track = ex.StackTrace
            };

            //记录系统日志
            SysLog.WriteError(task, notify);

            if ((notify.MsgLevel & MsgLevel) != notify.MsgLevel) return;

            NotifySysErrorMsgEvent?.Invoke(task, notify);
        }


        /// <summary>
        /// 记录测试信息
        /// </summary>
        /// <param name="msg"></param>
        public static void DebugMsg(string msg)
        {
            var taskInfo = Watcher.CurrentTask;

            var notifyInfo = new NotifyInfo()
            {
                Message = msg,
                MsgLevel =  MsgLevel.Debug,
            };

            OnNotifyMsg(taskInfo, notifyInfo);
        }

        /// <summary>
        /// 广播消息，用于模块间消息通知
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        public static void BroadcastMsg(int id,  string msg)
        {
            var taskInfo = Watcher.CurrentTask;

            var notifyInfo = new NotifyInfo()
            {
                BroadcastId = id,
                Message = msg,
                MsgLevel = MsgLevel.Notice
            };

            //广播信息时， 暂时标记状态为等待状态
            taskInfo.SetRunStatus(RunStatus.Waiting, notifyInfo);
        }
     
    }
}
