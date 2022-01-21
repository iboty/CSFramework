using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSFramework.Common.Data;
using CSFramework.MVVM.Data;

namespace CSFramework.Common.WinForm.Common
{
    public static  class UserTip
    {
        public static void ShowError(TaskInfo task, NotifyInfo notify)
        {
            if (task.RunInfo.Status != RunStatus.End  || notify.MessageCode == MessageCode.Success) return;
            MessageForm.Show(notify.MessageCode, notify.Message);
        }

        public static void SetResultHandle(TaskInfo task, NotifyInfo notify, Action successHandle)
        {
            if (task != null &&  task.RunInfo.Status != RunStatus.End ) return;

            if (notify.MessageCode == MessageCode.Success) successHandle();
            else MessageForm.Show(notify.MessageCode, notify.Message); ;
        }
    }
}
