﻿using CSFramework.Common.WinForm.Privileges.Data;
using CSFramework.Common.WinForm.Privileges.Model;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CSFramework.Common.WinForm.Privileges.Helper
{
    public static  class DataHelper
    {
        /// <summary>
        /// 获取所有模块描述
        /// </summary>
        /// <param name="control"></param>
        /// <param name="parentModel">
        /// </param>
        /// <returns></returns>
        public static PrivilegeModel GetPrivilegeModel(Control control, PrivilegeModel parentModel = null)
        {

            var desc = control as IPrivilegesDesc;
            PrivilegeModel model = null;

            switch (desc?.FuncType)
            {
                case FuncType.Element:
                case FuncType.Context:
                    return PrivilegeDescToModel(desc, parentModel);

                case FuncType.RootMenu:
                    model = PrivilegeDescToModel(desc, parentModel);
                    parentModel = model;
                    break;

                case FuncType.Menu:
                    model = PrivilegeDescToModel(desc, parentModel);
                    parentModel = model;

                    control = GetControlFromPath(desc.ViewPath);
                    if (control == null) return model;
                    break;
            }

            if (parentModel == null) return null;

            foreach (Control childControl in control.Controls)
            {
                var childControlDesc = GetPrivilegeModel(childControl, parentModel);
                if (childControlDesc == null) continue;

                parentModel.Models.Add(childControlDesc);
            }

            return model;
        }

        public static PrivilegeModel PrivilegeDescToModel(IPrivilegesDesc desc, PrivilegeModel parentModel)
        {
            if (desc == null) return null;

            var model = new PrivilegeModel
            {
                FuncPath = parentModel == null ? desc.FuncName : $"{parentModel.FuncPath}-{desc.FuncName}",
                ParentFuncPath = parentModel?.FuncPath,
                FuncName = desc.FuncName,
                FuncType  = desc.FuncType,
                OperaOwn = desc.OperaOwn,
                ViewPath = desc.ViewPath
            };

            return model;
        }

        public static Control GetControlFromPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;

            var assembly = Assembly.GetEntryAssembly();
            var control = assembly?.CreateInstance(path) as Control;

            if (control == null) throw new Exception($"无法加载模块：{path}");
            return control;
        }


    }
}
