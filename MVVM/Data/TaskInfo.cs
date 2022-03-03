using System;
using CSFramework.Common.Helper;
using CSFramework.MVVM.Interface;
using CSFramework.MVVM.Roles;

namespace CSFramework.MVVM.Data
{
    public class TaskInfo
    {
        private RunStatus _runStatus;

        public TaskInfo(string name, IFuncElement funcElement)
        {
            Name = name;
            FuncElement = funcElement;
        }

        /// <summary>
        /// 页面的功能元素
        /// </summary>
        public IFuncElement FuncElement { get; }

        /// <summary>
        /// 线程ID
        /// </summary>
        public int ThreadId { get; internal set; }

        /// <summary>
        /// 执行方式
        /// </summary>
        public ExecuteMode ExecuteMode { get; internal set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 当前运行状态
        /// </summary>
        public RunStatus RunStatus
        {
            get => _runStatus;
            internal  set => SetRunStatus(value, null);
        }

        /// <summary>
        /// 运行事件间隔
        /// </summary>
        public  RunTimeSpan RunTimeSpan { get; } = new RunTimeSpan();

        /// <summary>
        /// 运行次数
        /// </summary>
        public int RunCount { get; private set; }

        /// <summary>
        /// 运行结果
        /// </summary>
        public RunResult RunResult { get; private set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// 取消任务
        /// </summary>
        public void Cancel()
        {
            _runStatus = RunStatus.Cancel;
        }

        private void OnTaskNotifyMsg(TaskInfo task, NotifyInfo notify)
        {
            if(FuncElement?.TaskNotifyEvent == null) return;

            try
            {
                FuncElement.TaskNotifyEvent(task, notify);
            }
            catch (Exception e)
            {
                Notifier.SysErrorMsg(task,e);
            }
        }

        internal void SetRunStatus(RunStatus status, NotifyInfo notify)
        {
            if(_runStatus == status) return;

            _runStatus = status;

            //记录开始时间和结束时间等信息
            switch (_runStatus)
            {
                case RunStatus.Starting:
                    Exception = null;
                    RunResult = RunResult.None;
                    break;

                case RunStatus.Started:
                    RunTimeSpan.Start = DateTime.Now;
                    break;

                case RunStatus.Cancel:
                    RunResult = RunResult.Cancel;
                    break;

                case RunStatus.Ending:
                    RunResult = ComConvert.ExceptionToRunResult(Exception);
                    RunTimeSpan.End = DateTime.Now;
                    RunCount++;
                    break;
            }

            //通知的任务
            OnTaskNotifyMsg(this, notify);

            //通知器订阅触发
            Notifier.OnNotifyMsg(this, notify);
        }
    }
}
