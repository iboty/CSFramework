using System;
using CSFramework.MVVM.Data;
using CSFramework.MVVM.Interface;

// ReSharper disable once IdentifierTypo
namespace CSFramework.MVVM.Roles
{
    /// <summary>
    /// 向下命令者
    /// </summary>
    public class Commander
    {
        /// <summary>
        ///  执行过程
        /// </summary>
        /// <param name="func"></param>
        /// <param name="task"></param>
        private static void Execute(TaskInfo task, Action func)
        {
            Watcher.Process(task, func);
        }

        /// <summary>
        /// 执行线程
        /// </summary>
        /// <param name="func">业务方法</param>
        /// <param name="task"></param>
        private static void ExecuteThread(TaskInfo task, Action func)
        {
            Watcher.ProcessThread(task, func);
        }

       /// <summary>
       /// 注册顺序执行方法
       /// </summary>
       /// <param name="taskName"></param>
       /// <param name="funcElement"></param>
       /// <param name="bllFunc"></param>
        public static void Register(string taskName,IFuncElement funcElement, Action bllFunc)
        {
           var task = new TaskInfo(taskName,funcElement){ExecuteMode =  ExecuteMode.Order};
           funcElement.ActionEvent += () => Execute(task, bllFunc);
        }
       
       
        public static void RegisterThread(string taskName, IFuncElement funcElement, Action bllFunc)
        {
            var task = new TaskInfo(taskName, funcElement) { ExecuteMode = ExecuteMode.Async }; ;
            funcElement.ActionEvent += () => ExecuteThread(task, bllFunc);
        }

       
    }
}
