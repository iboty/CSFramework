using System;
using System.Linq;
using CSFramework.MVVM.Attributes;

namespace CSFramework.MVVM.Models
{
    public class ModelBackup
    {
        /// <summary>
        /// 备份模型
        /// </summary>
        private object _backupModel;
        /// <summary>
        /// 当前模型
        /// </summary>
        private object _curModel;

        /// <summary>
        /// 检查模型值是否改变
        /// </summary>
        /// <returns></returns>
        public bool CheckChanged()
        {
            var modelPropertyArray = _curModel.GetType().GetProperties();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.BackupIgnore == true) continue;

                var curModelPropertyValue = modelProperty.GetValue(_curModel, null);
                var backupModePropertyValue = modelProperty.GetValue(_backupModel, null);

                if (curModelPropertyValue != backupModePropertyValue) return true;

            }
            return false;
        }

        /// <summary>
        /// 撤销已经修改的模型值
        /// </summary>
        public void CancelChanged()
        {
            var modelPropertyArray = _curModel.GetType().GetProperties();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.BackupIgnore == true) continue;
                var backupModePropertyValue = modelProperty.GetValue(_backupModel, null);
                modelProperty.SetValue(_curModel, backupModePropertyValue, null);
            }
          
        }

        public void UpdateValue()
        {
            var modelPropertyArray = _curModel.GetType().GetProperties();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.BackupIgnore == true) continue;
                var curModelPropertyValue = modelProperty.GetValue(_curModel, null);
                modelProperty.SetValue(_backupModel, curModelPropertyValue, null);
            }
        }

        internal void InitValue(object model)
        {
            _curModel = model;
            _backupModel = Activator.CreateInstance(model.GetType());
        }
    }
}
