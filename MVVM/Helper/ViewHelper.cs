using System;
using CSFramework.MVVM.Data;
using CSFramework.MVVM.Interface;
using CSFramework.Privileges.StyleBase;

namespace CSFramework.MVVM.Helper
{
    public  class ViewHelper
    {
        /// <summary>
        /// 初始化后台
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelView"></param>
        /// <param name="taskEvent"></param>
        public static void InitBackground<T>(T modelView, Action<TaskInfo, NotifyInfo> taskEvent = null) where T : BaseView
        {
           // Commander.Register($"{modelView.ViewName} UI模块初始化",modelView, "Load", ()=> InitViewHandle(modelView), null, taskEvent);
        }
        /// <summary>
        /// 异步初始化后台
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelView"></param>
        /// <param name="taskEvent"></param>
        public static void AsyncInitBackground<T>(T modelView, Action<TaskInfo, NotifyInfo> taskEvent = null) where T : BaseView
        {
           // Commander.RegisterThread($"{modelView.ViewName} UI模块初始化", modelView, "Load", () => InitViewHandle(modelView), null, taskEvent);
        }

        private static void InitViewHandle(IModelView modelView)
        {
            modelView.InitBll();
            modelView.InitBindData();
            modelView.InitRegister();
        }

       
    }
}
