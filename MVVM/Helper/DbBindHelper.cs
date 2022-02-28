using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using CSFramework.Common.Data;
using CSFramework.MVVM.Attributes;
using CSFramework.MVVM.Models;
using CSFramework.MVVM.Roles;

namespace CSFramework.MVVM.Helper
{
    public  class DbBindHelper
    {
        public static void LinkConfig<T1, T2>(T2 model,Func<List<T1>> getEntitiesFunc, Action<T1> addAction,  Action<T1> updateAction) where T2 :ModelBase where T1 : new()
        {
            var entities = getEntitiesFunc();

            var modelType = model.GetType();
            var modelProperties = modelType.GetProperties();
            var linkAttr =  (ConfigLinkAttr)modelType.GetCustomAttribute(typeof(ConfigLinkAttr));
            if(linkAttr == null) throw new Exception("配置参数模型未添加Link属性");

           
            var entityProperties = typeof(T1).GetProperties();
            var keyProperty = entityProperties.FirstOrDefault(t => t.Name == linkAttr.KeyPropertyName);
            if (keyProperty == null) throw new Exception($"配置实体类中未发现属性{linkAttr.KeyPropertyName}");

            var valueProperty = entityProperties.FirstOrDefault(t => t.Name == linkAttr.ValuePropertyName);
            if (valueProperty == null) throw new Exception($"配置实体类中未发现属性{linkAttr.ValuePropertyName}");

            var descProperty = entityProperties.FirstOrDefault(t => t.Name == linkAttr.DescPropertyName);
            if (descProperty == null) throw new Exception($"配置实体类中未发现属性{linkAttr.DescPropertyName}");

            foreach (var modelProperty in modelProperties)
            {
                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) continue;


                var entity = entities.FirstOrDefault(t => keyProperty.GetValue(t)?.Equals(modelProperty.Name) == true);

                if (entity == null)
                {
                    var value = Convert.ToString(modelProperty.GetValue(model));
                    var desc = modelPropertyAttr?.Desc;

                    entity = new T1();
                    keyProperty.SetValue(entity, modelProperty.Name);
                    valueProperty.SetValue(entity, value);
                    descProperty.SetValue(entity,desc);

                    addAction(entity);
                }
                else
                {
                    var entityValue = valueProperty.GetValue(entity);
                    var value = MeConvert.ToCommonValue(entityValue, typeof(string), modelProperty.PropertyType);
                    modelProperty.SetValue(model, value);
                }
            }

            model.PropertyChanged += (obj, args) => ModelValueChangedHandle<T1>(obj, args.PropertyName, keyProperty,
                valueProperty, descProperty, updateAction);
        }

        private static void ModelValueChangedHandle<T>(object model,string modelPropertyName ,PropertyInfo keyProperty, PropertyInfo valueProperty, PropertyInfo descProperty, Action<T> updateAction) where T : new()
        {
            try
            {
                var property = model.GetType().GetProperty(modelPropertyName);
                if (property == null) return;

                var modelPropertyAttr = (ValuePropertyAttr)property.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) return;

                var entity = new T();
                keyProperty.SetValue(entity, property.Name);
                valueProperty.SetValue(entity, Convert.ToString(property.GetValue(model)));
                descProperty.SetValue(entity, modelPropertyAttr?.Desc);
                updateAction(entity);
            }
            catch (Exception e)
            {
               Notifier.DebugMsg($"配置信息同步失败,{e.Message}");
            }
        }
    }
}
