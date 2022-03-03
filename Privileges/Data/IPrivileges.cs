namespace CSFramework.Privileges.Data
{
    /// <summary>
    /// 关于 控件元素的信息说明
    /// </summary>
    public interface IPrivileges
    {
        /// <summary>
        /// 功能路径
        /// </summary>
        string FuncPath {get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        string FuncName { get; set; }
        /// <summary>
        /// 功能类型
        /// </summary>
        FuncType FuncType { get; }
        /// <summary>
        /// 拥有操作
        /// </summary>
        OperaType OperaOwn { get; } 
        /// <summary>
        /// 菜单模式下 页面地址
        /// </summary>
        string ViewPath { get; set; }
        /// <summary>
        /// 加载初始化
        /// </summary>
        /// <param name="operaType"></param>
        void LoadInit(OperaType operaType);


    }
}
