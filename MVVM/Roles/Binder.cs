using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using CSFramework.MVVM.Models;

namespace CSFramework.MVVM.Roles
{
    /// <summary>
    /// 双向绑定者
    /// </summary>
    public static class Binder
    {
        public static void LinkList<T>(DataGridView dataGridView, ModelList<T> modelList, bool isSync = false) where T : ModelBase , new()
        {
            if (isSync) modelList.InitSynchronizationContext();

            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = modelList;
        }

        public static void LinkList<T>(ComboBox comboBox, ModelList<T> modelList, string keyName, string valueName) where T : ModelBase, new()
        {
            comboBox.DataSource = modelList;
            comboBox.DisplayMember = keyName;
            comboBox.ValueMember = valueName;
        }

        /// <summary>
        ///  数据模块与控件属性绑定 
        /// </summary>
        /// <param name="ctrl">绑定控件</param>
        /// <param name="ctrlExpression">控件属性表达式</param>
        /// <param name="model">绑定模型</param>
        /// <param name="modelExpression">绑定模型表达式</param>
        /// <param name="isSync">是否同步数据</param>
        public static void Link<T1,T2,T3,T4>(T1 ctrl, Expression<Func<T1, T3>> ctrlExpression, T2 model, Expression<Func<T2, T4>> modelExpression, bool isSync = false) where T1 : Control where T2 : ModelBase
        {
            var ctrlPropertyName = ((MemberExpression)ctrlExpression.Body).Member.Name;
            var modelPropertyName = ((MemberExpression)modelExpression.Body).Member.Name;
            Link(ctrl, ctrlPropertyName, model, modelPropertyName);
        }
        private static void Link<T1, T2>(T1 ctrl, string ctrlPropertyName, T2 model, string modelPropertyName) where T1 : Control where T2 : ModelBase
        {
            var b = new Binding(ctrlPropertyName, model, modelPropertyName,true);
            ctrl.DataBindings.Add(b);
        }
    }
}
