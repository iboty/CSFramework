using System;
using CSFramework.Common.Data;

namespace CSFramework.MVVM.Data
{
    public class RegArgs
    {
        public RegArgs(Func<object> argLogic, Action<TaskInfo, NotifyInfo> taskEvent)
        {
            ArgLogic = argLogic;
            TaskEvent = taskEvent;
        }

        public RegArgs SetEventArgs(object sender, EventArgs args)
        {
            Sender = sender;
            EventArgs = args;
            return this;
        }

        /// <summary>
        /// 将定时的任务状态绑定定时器控件上，用于选择不同状态下的间隔时长
        /// </summary>
        /// <param name="timer"></param>
        internal  void BindTimerMode(TaskTimer timer)
        {
            TaskEvent += (t, m) =>
            {
                if (m.MessageCode == MessageCode.Fault) timer.SetErrorTaskMode(true);
                if (m.MessageCode == MessageCode.Success) timer.SetErrorTaskMode(false);
            };
        }

        /// <summary>
        /// 传参的委托
        /// </summary>
        public Func<object> ArgLogic {get;  set;}

        /// <summary>
        ///  执行状态改变委托包含（开始 结束）
        /// </summary>
        public Action<TaskInfo,NotifyInfo> TaskEvent { get; private set; }

        /// <summary>
        /// 事件对象
        /// </summary>
        public object Sender { get; private set;}

        /// <summary>
        /// 事件参数
        /// </summary>
        public EventArgs EventArgs { get; private set; }
      

    }
}
