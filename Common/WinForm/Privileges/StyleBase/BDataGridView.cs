﻿using System;
using System.Windows.Forms;
using CSFramework.Common.WinForm.Privileges.Data;

namespace CSFramework.Common.WinForm.Privileges.StyleBase
{
    public  class BDataGridView : DataGridView , IPrivilegesDesc
    {
        public string FuncPath { get; set; }
        public string FuncName { get; set; }

        public FuncType FuncType => FuncType.ListContext;

        public OperaType OperaOwn => OperaType.Browsable | OperaType.Add | OperaType.Del | OperaType.Edit;

        public string ViewPath { get; set;}

        public void LoadInit(OperaType operaType)
        {
            throw new NotImplementedException();
        }
    }
}
