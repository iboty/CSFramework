using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSFramework.Common.Data;
using CSFramework.MVVM.Roles;

namespace CSFramework.Common.Helper
{
    public  class TaskHelper
    {
        public static void RunWithoutError(string taskName, Action fun)
        {
            try
            {
                fun();
            }
            catch (Exception e)
            {
               Notifier.CollectCustomMsg(taskName, MessageCode.Fault, e.Message);
            }
        }

        public static void RunThread(Action func)
        {
            var thread = new Thread(()=>func()) {IsBackground = true};
            thread.Start();
        }

        public static void RunLoop(string taskName, Action fun,ref bool isRun)
        {
            while (isRun)
            {
                try
                {
                    fun();
                }
                catch (Exception e)
                {
                    Notifier.CollectCustomMsg(taskName, MessageCode.Fault, e.Message);
                }
            }
        }
    }
}
