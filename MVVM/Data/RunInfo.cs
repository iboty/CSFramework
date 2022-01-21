using System;

namespace CSFramework.MVVM.Data
{
    public class RunInfo
    {
        public RunInfo()
        {
            Status = RunStatus.Start;
        }

        public RunStatus Status { get; set; } 

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; private set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; private set; }
        /// <summary>
        /// 运行时间间隔
        /// </summary>
        public TimeSpan RunTimeSpan => (EndTime??DateTime.Now) - StartTime;


        internal void SetStatus(RunStatus status, DateTime dateTime)
        {
            Status = status;

            switch (Status)
            {
                case RunStatus.Process:
                    StartTime = dateTime; 
                    break;

                case RunStatus.End:
                    EndTime = dateTime;
                    break;

                case RunStatus.Start:
                    break;

                case RunStatus.Continue:
                    break;
                default:
                    break;
            }
        }
    }
}
