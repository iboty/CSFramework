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
        /// <param name="regInfo"></param>
        /// <param name="regArgs">运行参数</param>
        public static void ProcessThread(Action func, RegInfo regInfo, RegArgs regArgs)
        {
            var thread = new Thread(() => Process(func, regInfo, regArgs)){IsBackground = true};
            thread.Start();
        }


        private static void LockAddTask(TaskInfo info)
        {
            //防止都线程篡改
            lock (TaskInfoDic)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                if (TaskInfoDic.ContainsKey(threadId)) TaskInfoDic[threadId].Add(info);
                else TaskInfoDic.Add(threadId, new List<TaskInfo> {info});
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

        public static void Continue(TaskInfo info)
        {

        }


        /// <summary>
        /// 守护方法过程
        /// </summary>
        /// <param name="func">守护方法</param>
        /// <param name="regInfo">处理信息</param>
        /// <param name="regArgs">参数信息</param>
        public static void Process(Action func, RegInfo regInfo, RegArgs regArgs)
        {
            //初始化任务
            var info = new TaskInfo(regInfo, regArgs);

            //任务信息添加缓存
            //收集启动消息
            Notifier.OnNotifyMsg(info, new NotifyInfo());

            //撤销
            if (info.IsCancel) return;

            LockAddTask(info);
            
            info.RunInfo.SetStatus(RunStatus.Start,DateTime.Now);

            Exception exception = null;
            try
            {
                func();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            ;
            info.RunInfo.SetStatus(RunStatus.End, DateTime.Now);

            LockRemoveTask(info);

            Notifier.OnNotifyMsg(info, new NotifyInfo(exception));
            
        }
    }
}
