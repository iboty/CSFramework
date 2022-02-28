using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CSFramework.Common.Interface;
using CSFramework.MVVM.Data;

namespace CSFramework.MVVM.Interface
{
    /// <summary>
    /// 具有功能，权限控制元素接口
    /// </summary>
    public interface IFuncElement : IBaseElement
    {
        /// <summary>
        /// 功能触发事件
        /// </summary>
        event Action ActionEvent;

        /// <summary>
        /// 任务通知事件
        /// </summary>
        Action<TaskInfo, NotifyInfo> TaskNotifyEvent {get; set;}
    }
}
