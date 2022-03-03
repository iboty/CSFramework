using System.Collections.Generic;
using System.Windows.Forms;
using CSFramework.Privileges.Data;

namespace CSFramework.Privileges.StyleBase
{
    public class BMenuButton : Button ,IPrivileges
    {
        public string FuncPath { get; set; }
        public string FuncName { get; set; }

        public FuncType FuncType => FuncType.Menu;

        public OperaType OperaOwn => OperaType.Browsable;

        public string ViewPath { get; set; }

        public List<IPrivileges> ControlDescList { get; set; }

        public void LoadInit(OperaType operaType)
        {
            Visible = (operaType & OperaType.Browsable) == OperaType.Browsable;
        }
    }
}
