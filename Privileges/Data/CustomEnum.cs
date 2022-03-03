using System;

namespace CSFramework.Privileges.Data
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
        /// <summary>
        /// 列表内容
        /// </summary>
        ListContext,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    [Flags]
    public enum OperaType
    {
        /// <summary>
        /// 可浏览
        /// </summary>
        Browsable = 01,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 02,
        /// <summary>
        /// 添加 列表权限
        /// </summary>
        Add = 03,
        /// <summary>
        /// 删除 列表权限                                                                                                                                                               
        /// </summary>
        Del = 04,

    }
}
