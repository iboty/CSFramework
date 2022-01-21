using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using CSFramework.Common.Data;
using CSFramework.MVVM.Data;
using Timer = System.Timers.Timer;

// ReSharper disable once IdentifierTypo
namespace CSFramework.MVVM.Roles
{
    /// <summary>
    /// 向下命令者
    /// </summary>
    public class Commander
    {
        private static readonly Dictionary<RegInfo , RegEventInfo> RegisterDictionary = new Dictionary<RegInfo, RegEventInfo>();
        /// <summary>
        ///  执行过程
        /// </summary>
        /// <param name="func">业务方法</param>
        /// <param name="regInfo"></param>
        /// <param name="regArgs"></param>
        public static void Execute(Action func, RegInfo regInfo, RegArgs regArgs)
        {
            Watcher.Process(func, regInfo, regArgs);
        }

        /// <summary>
        /// 执行线程
        /// </summary>
        /// <param name="func">业务方法</param>
        /// <param name="regInfo"></param>
        /// <param name="regArgs"></param>
        public static void ExecuteThread(Action func,RegInfo regInfo, RegArgs regArgs)
        {
            Watcher.ProcessThread(func, regInfo, regArgs);
        }
        /// <summary>
        ///  对象事件注册执行的业务方法
        /// </summary>
        /// <param name="regName">注册名称</param>
        /// <param name="regObj">注册对象</param>
        /// <param name="regEvent">注册事件</param>
        /// <param name="regFunc">注册方法</param>
        /// <param name="argLogic">参数逻辑</param>
        /// <param name="taskEvent">任务事件</param>
        public static void Register(string regName, object regObj, string regEvent, Action regFunc, Func<object> argLogic = null, Action<TaskInfo, NotifyInfo> taskEvent = null)
        {
            var regInfo = new RegInfo(regName,regObj, regEvent, TaskType.General);
            var regArgs = new RegArgs(argLogic, taskEvent);
            regInfo.BindTask((o, e) => Execute(regFunc, regInfo, regArgs.SetEventArgs(o, e)));
         
        }

        public static void RegisterThread(string regName, object regObj, string regEvent, Action regFunc, Func<object> argLogic = null, Action<TaskInfo, NotifyInfo> taskEvent = null)
        {
            var regInfo = new RegInfo(regName, regObj, regEvent, TaskType.Thread);
            var regArgs = new RegArgs(argLogic, taskEvent);

            regInfo.BindTask((o, e) => ExecuteThread(regFunc, regInfo, regArgs.SetEventArgs(o, e)));

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="regName"></param>
        /// <param name="regFunc"></param>
        /// <param name="timer"></param>
        /// <param name="isStart"></param>
        /// <param name="argLogic"></param>
        /// <param name="taskEvent"></param>
        /// <returns></returns>
        public static void RegisterTimer(string regName, TaskTimer timer, Action regFunc, bool isStart ,Func<object> argLogic = null, Action<TaskInfo, NotifyInfo> taskEvent = null)
        {
            var regInfo = new RegInfo(regName,timer, nameof(timer.Triggered), TaskType.Timer);
            var regArgs = new RegArgs(argLogic, taskEvent);

            //如果设置了异常定时间隔时长， 需要订阅任务的状态
            if (timer.ErrorIntervalLen != Timeout.Infinite) regArgs.BindTimerMode(timer);

            regInfo.BindTask((o, e) => Execute(regFunc, regInfo, regArgs.SetEventArgs(o, e)));

            if(isStart) timer.Start();
        }


    }
}
