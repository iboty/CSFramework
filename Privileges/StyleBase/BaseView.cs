using System.Windows.Forms;
using CSFramework.Privileges.Data;

namespace CSFramework.Privileges.StyleBase
{
    public  class BaseView : UserControl
    {
        ////public event EventHandler InitEvent;


        public BaseView(IPrivileges desc) : this()
        {
            
        }

        IPrivileges PrivilegesDesc { get; set; }

        public BaseView()
        {

        }
    }
}
