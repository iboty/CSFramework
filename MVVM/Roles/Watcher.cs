# define TEST

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSFramework.MVVM.Data;

namespace CSFramework.MVVM.Roles
{

    /// <summary>
    /// 监视过程
    /// </summary>
    public static class Watcher
    {
        public static readonly  Dictionary<int, List<TaskInfo>> TaskInfoDic = new Dictionary<int, List<TaskInfo>>();

        public static TaskInfo CurrentTask => GetCurrentTaskInfo();

        public static TaskInfo GetCurrentTaskInfo()
        {
            lock (TaskInfoDic)
            {
                return TaskInfoDic.ContainsKey(Thread.CurrentThread.ManagedThreadId) ? 
                    TaskInfoDic[Thread.CurrentThread.ManagedThreadId].Last() : null;
            }
        }

        /// <summary>
        /// 守护线程方法过程
        /// </summary>
        /// <param name="func">守护方法</param>
        /// <param name="task"></param>
        public static void ProcessThread(TaskInfo task, Action func)
        {
            var thread = new Thread(() => Process(task,func)){IsBackground = true};
            thread.Start();
        }


        private static void LockAddTask(TaskInfo info)
        {
            //防止都线程篡改
            lock (TaskInfoDic)
            {
                info.ThreadId = Thread.CurrentThread.ManagedThreadId;

                if (TaskInfoDic.ContainsKey(info.ThreadId)) TaskInfoDic[info.ThreadId].Add(info);

                else TaskInfoDic.Add(info.ThreadId, new List<TaskInfo> {info});
            }
        }

        private static void LockRemoveTask(TaskInfo info)
        {
            //防止都线程篡改
            lock (TaskInfoDic)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                var taskList = TaskInfoDic[threadId];
                taskList.Remove(info);
                if (taskList.Count == 0) TaskInfoDic.Remove(threadId);
            }
        }

        /// <summary>
        /// 守护方法过程
        /// </summary>
        /// <param name="func">任务过程</param>
        /// <param name="task">任务信息</param>
        public static void Process(TaskInfo task, Action func)
        {
            //任务准备
            task.RunStatus = RunStatus.Starting;
         

            //如果任务撤销，结束任务
            if (task.RunStatus == RunStatus.Cancel) return;
          
            //添加任务信息
            LockAddTask(task);

            //切换任务开始
            task.RunStatus = RunStatus.Started;

            try
            {
                func();
            }
            catch(Exception ex)
            {
                task.Exception = ex;
            }

            //任务准备结束
            task.RunStatus = RunStatus.Ending;

            //执行完成，删除任务信息
            LockRemoveTask(task);

            //切换任务结束状态
            task.RunStatus = RunStatus.Ended;
        }
    }
}
