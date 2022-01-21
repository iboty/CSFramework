using System;
using System.Reflection;
using System.Windows.Forms;

namespace CSFramework.MVVM.Data
{
    public  class RegEventInfo
    {
        public RegEventInfo(object eventObj, string eventName)
        {
            EventObj = eventObj;

            EventInfo = EventObj.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
            if (EventInfo == null) throw new Exception($"{eventObj}的目标事件{EventInfo}为空");
        }

        public void Bind(EventHandler eventHandle)
        {
            EventHandle = eventHandle;
            EventInfo.AddEventHandler(EventObj, EventHandle);
        }

        /// <summary>
        /// 是否注册信息
        /// </summary>
        public void Unbind()
        {
            EventInfo.RemoveEventHandler(EventObj, EventHandle);
        }


        /// <summary>
        /// 执行控件
        /// </summary>
        public object EventObj { get; private set; }
        /// <summary>
        /// 事件信息
        /// </summary>
        public EventInfo EventInfo { get; private set; }
        /// <summary>
        /// 处理事件的订阅
        /// </summary>
        public EventHandler EventHandle { get; private set; }

      
        /// <summary>
        /// 释放事件的订阅
        /// </summary>
        public EventHandler ReleaseHandler { get; set; }
    }
}
