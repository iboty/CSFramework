using System.Collections.Generic;
using System.Windows.Forms;
using CSFramework.Common.WinForm.Privileges.Data;

namespace CSFramework.Common.WinForm.Privileges.StyleBase
{
    public class BTextBox :TextBox, IPrivilegesDesc
    {
        public string FuncPath { get; set; }
        public string FuncName { get; set; }

        public FuncType FuncType => FuncType.Context;

        public OperaType OperaOwn => OperaType.Edit | OperaType.Browsable;

        public string ViewPath { get; set; }

        public List<IPrivilegesDesc> ControlDescList { get; set; }


        public void LoadInit(OperaType operaType)
        {
            Visible = (operaType & OperaType.Browsable) == OperaType.Browsable;

            ReadOnly = (operaType & OperaType.Edit) == OperaType.Edit;
        }
    }
}
