
using System;
using System.Reflection;

namespace CSFramework.MVVM.Data
{
    public class RegInfo
    {
        public RegInfo(string taskName, object taskObj,string taskEvent,  TaskType taskType = TaskType.General)
        {
            TaskObj = taskObj;
            TaskName = taskName;
            TaskType = taskType;
            TaskEvent = taskEvent;

        }

        /// <summary>
        /// 注册任务对象
        /// </summary>
        public object TaskObj { get; }
        /// <summary>
        /// 注册事件
        /// </summary>
        public string TaskEvent { get; set;}
        /// <summary>
        /// 注册名称
        /// </summary>
        public string TaskName { get; }
        /// <summary>
        ///  注册类型
        /// </summary>
        public TaskType TaskType { get; }

        internal void BindTask(EventHandler eventHandler)
        {
            var eventInfo = TaskObj.GetType().GetEvent(TaskEvent, BindingFlags.Instance | BindingFlags.Public);
            if (eventInfo == null) throw new Exception($"{TaskObj}的目标事件{TaskEvent}为空");
            eventInfo.AddEventHandler(TaskObj,eventHandler);
        }

    }
}
