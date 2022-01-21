using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSFramework.Common.WinForm.Data;

namespace CSFramework.Common.WinForm.StyleBase
{
    public class BTextBox :TextBox, IControlDesc
    {
        public string FuncPath { get; set; }
        public string FuncName { get; set; }

        public FuncType FuncType => FuncType.Context;

        public OperaType OperaOwn => OperaType.Edit | OperaType.Visible;

        public string ViewPath { get; set; }

        public List<IControlDesc> ControlDescList { get; set; }


        public void LoadInit(OperaType operaType)
        {
            Visible = (operaType & OperaType.Visible) == OperaType.Visible;

            ReadOnly = (operaType & OperaType.Edit) == OperaType.Edit;
        }
    }
}
