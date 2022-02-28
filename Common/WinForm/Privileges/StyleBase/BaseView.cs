using System;
using System.Windows.Forms;
using CSFramework.Common.WinForm.Privileges.Data;

namespace CSFramework.Common.WinForm.Privileges.StyleBase
{
    public  class BaseView : UserControl
    {
        ////public event EventHandler InitEvent;


        public BaseView(IPrivilegesDesc desc) : this()
        {
            
        }

        IPrivilegesDesc PrivilegesDesc { get; set; }

        public BaseView()
        {

        }
    }
}
