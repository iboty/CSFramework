using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using CSFramework.MVVM.Attributes;
using CSFramework.MVVM.Data;
using CSFramework.MVVM.Helper;

namespace CSFramework.MVVM.Models
{
    /// <summary>
    ///  数据模型基础类
    /// </summary>
    public class ModelBase : INotifyPropertyChanged
    {

        #region[构造方法]
        #endregion

        #region[公共属性]
        /// <summary>
        /// 备份模型
        /// </summary>
        [ValuePropertyAttr(Ignore = true)]
        public ModelBackup ModelBackup { get; protected set; }
        /// <summary>
        ///  值是否发生改变
        /// </summary>
        [ValuePropertyAttr(Ignore = true)]
        public bool Changed { get;  protected set; }
        /// <summary>
        /// 界面同步上下文，当出现异步线程需要对绑定的界面属性做异步操作
        /// </summary>
        [ValuePropertyAttr(Ignore = true)]
        public SynchronizationContext SynchronizationContext { get;  set; }
        #endregion


        #region[公共事件和委托]


        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region[私有属性]
        #endregion

        #region[静态方法]

        public static T  NewModelFromEntity<T>(object entity)  where  T : ModelBase , new()
        {
            var model = new T ();
            model.UpdateFromEntity(entity);
            return model;
        }



        #endregion

        #region[公共方法]

        public void InitSynchronizationContext()
        {
            SynchronizationContext = SynchronizationContext.Current;
        }

        

        /// <summary>
        /// 创建备份模型
        /// </summary>
        public void CreateModelBackUp()
        {
            if(ModelBackup != null) return;

            ModelBackup = new ModelBackup();
            ModelBackup.InitValue(this);
        }
        /// <summary>
        /// 释放模型
        /// </summary>
        public void ReleaseModelBackUp()
        {
            ModelBackup = null;
        }

        /// <summary>
        ///  刷新属性通知
        /// </summary>
        public void RefreshPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        /// <summary>
        /// 从数据实体数据库中更新模型数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void UpdateFromEntity<T>(T entity)
        {
            var entityType = entity.GetType();
            if (entity == null) throw new ArgumentNullException($"{entityType.Name} is null");
            var modelPropertyArray = GetType().GetProperties();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr =
                    (ValuePropertyAttr)
                    modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) continue;

                var entityPropertyName = string.IsNullOrEmpty(modelPropertyAttr?.EntityPropertyName)
                    ? modelProperty.Name
                    : modelPropertyAttr.EntityPropertyName;

                var entityProperty = entityType.GetProperty(entityPropertyName);
                if (entityProperty == null)
                    throw new Exception($"{entityType.Name} 对象，不存在属性{entityPropertyName},无法进行属性值转换");

                var entityValue = entityProperty.GetValue(entity, null);
                var modelPropertyValue = MeConvert.ToCommonValue(entityValue, entityProperty.PropertyType,
                    modelProperty.PropertyType, modelPropertyAttr?.DefaultValue);

                modelProperty.SetValue(this, modelPropertyValue, null);
            }
        }

        /// <summary>
        /// 根据模型更新模型的属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public void UpdateFromModel<T>(T model) where T : ModelBase
        {
            var modelPropertyArray = GetType().GetProperties();
            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr =
                    (ValuePropertyAttr)
                    modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) continue;

                var propertyValue = modelProperty.GetValue(model, null);
                modelProperty.SetValue(this, propertyValue, null);
            }
        }

        public void SetValue(string propertyName, object value)
        {
            var property = GetType().GetProperty(propertyName);
            property?.SetValue(this,value,null);
        }

        /// <summary>
        /// 根据模型更新模型的属性值
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="model"></param>
        public void UpdateFromParentModel<T1>(T1 model) where T1 : ModelBase
        {
            var modelPropertyArray = typeof(T1).GetProperties();
            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) continue;

                var propertyValue = modelProperty.GetValue(model, null);
                modelProperty.SetValue(this, propertyValue, null);
            }
        }


        /// <summary>
        ///  将model属性值设置为实体类的属性值
        /// </summary>
        /// <typeparam name="T">每张表单类型</typeparam>
        /// <returns></returns>
        public T ToEntity<T>() where T : new()
        {
            var modelPropertyArray = GetType().GetProperties();

            var entity = new T();
            var entityType = entity.GetType();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyValue = modelProperty.GetValue(this, null);

                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();

                if (modelPropertyAttr?.Ignore == true) continue;

                var entityPropertyName = string.IsNullOrEmpty(modelPropertyAttr?.EntityPropertyName)
                    ? modelProperty.Name
                    : modelPropertyAttr.EntityPropertyName;

                var entityProperty = entityType.GetProperty(entityPropertyName);
                if (entityProperty == null) throw new Exception($"{ entityType.Name}对象，不存在属性{entityPropertyName},无法进行属性值转换");
                var entityValue = MeConvert.ToCommonValue(modelPropertyValue, modelProperty.PropertyType, entityProperty.PropertyType, modelPropertyAttr?.DefaultValue);
             
                entityProperty.SetValue(entity, entityValue, null);
            }

            return entity;
        }


        #endregion

     



        #region[保护方法]
        protected void SetPropertyValue<T>(T newValue, ref T curValue, string propertyName, string otherPropertyName = null)
        {
            if (Equals(newValue, curValue)) return;

            curValue = newValue;

            //模型在异步线程应用时需要考虑同步数据
            if (SynchronizationContext == null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                SynchronizationContext.Send(t=>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)) , null);
            }
            
            if(otherPropertyName != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(otherPropertyName));

            //赋值后标注, 值改变了
            if (!Changed) Changed = true;
        }
        #endregion

       
    }
}
