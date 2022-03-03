using System.Collections.Generic;
using CSFramework.MVVM.Models;
using CSFramework.Privileges.Data;

namespace CSFramework.Privileges.Model
{
    public class PrivilegeModel : ModelBase
    {
        /// <summary>
        /// 功能路径
        /// </summary>
        public  string FuncPath { get; set; }
        /// <summary>
        /// 功能父路径
        /// </summary>
        public string ParentFuncPath { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string FuncName { get; set; }
        /// <summary>
        /// 功能类型
        /// </summary>
        public FuncType FuncType { get; set; }

        /// <summary>
        /// 拥有操作
        /// </summary>
        public OperaType OperaOwn { get; set; }

        /// <summary>
        /// 菜单模式下 页面地址
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// 子控件信息列表
        /// </summary>
        public List<PrivilegeModel> Models { get; set; } = new List<PrivilegeModel>();
    }
}
