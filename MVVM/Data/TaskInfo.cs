using System.Threading;

namespace CSFramework.MVVM.Data
{
    public class TaskInfo
    {
        public TaskInfo(string name)
        {
            TaskName = name;
            TaskId = Thread.CurrentThread.ManagedThreadId.ToString();
            RunInfo = new RunInfo();
        }

        public TaskInfo(RegInfo regInfo, RegArgs regArgs)
        {
            RegInfo = regInfo;
            RegArgs = regArgs;
            TaskName = regInfo.TaskName;
            RunInfo = new RunInfo();
        }

        /// <summary>
        /// 任务id
        /// </summary>
        public string TaskId { get; set;}
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        ///  事件注册信息
        /// </summary>
        public RegInfo RegInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        public RegArgs RegArgs { get; }

        /// <summary>
        /// 
        /// </summary>
        public RunInfo RunInfo { get; }

        public bool IsCancel { get; private set; } 

        public void Cancel()
        {
            IsCancel = true;
        }

    }
}
