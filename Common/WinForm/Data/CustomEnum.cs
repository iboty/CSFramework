using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.WinForm.Data
{
    public enum FuncType
    {
        /// <summary>
        /// 根节点 一般指软件的一级容器
        /// </summary>
        RootMenu,
        /// <summary>
        /// 菜单
        /// </summary>
        Menu,
        /// <summary>
        /// 元素
        /// </summary>
        Element,
        /// <summary>
        /// 内容
        /// </summary>
        Context,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    [Flags]
    public enum OperaType
    {
        /// <summary>
        /// 拥有
        /// </summary>
        Visible = 01,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 02,

    }
}
