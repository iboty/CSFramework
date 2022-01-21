using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSFramework.Common.WinForm.Data;

namespace CSFramework.Common.WinForm.StyleBase
{
    public  class BaseView : UserControl
    {
        public event EventHandler InitEvent;


        public BaseView(IControlDesc controlDesc) : this()
        {
           



        }

        IControlDesc ControlDesc { get; set; }

        public BaseView()
        {

        }
    }
}
