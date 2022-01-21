using System;
using System.Linq;
using CSFramework.MVVM.Attributes;
using CSFramework.MVVM.Models;

namespace CSFramework.MVVM.Helper
{
    public static class MeConvert
    {
        /// <summary>
        /// 功能：将表单中的字段类型进行类型转换  
        /// </summary>
        /// <param name="value">每个实体类中的字段</param>
        /// <param name="valueType">字段类型</param>
        /// <param name="newValueType">新类型</param>
        /// <param name="defaultVale"></param>
        /// <returns></returns>
        public static object ToCommonValue(object value, Type valueType, Type newValueType, object defaultVale = null)
        {
            if (value == null && defaultVale != null) value = defaultVale;

            if (newValueType == valueType) return value;

            if (newValueType == typeof (string)) return Convert.ToString(value);
            if (newValueType == typeof (int)) return Convert.ToInt32(value);
            if (newValueType == typeof (double)) return Convert.ToDouble(value);
            if (newValueType == typeof(byte)) return Convert.ToByte(value);

            if (newValueType == typeof (bool))
            {
                if (!(value is string s)) return Convert.ToBoolean(value);
                if (string.Equals(s, "false", StringComparison.CurrentCultureIgnoreCase)) return false;
                if (string.Equals(s, "true", StringComparison.CurrentCultureIgnoreCase)) return true;
                return Convert.ToBoolean(Convert.ToInt32(value));
            }

            if (newValueType == typeof (short)) return Convert.ToInt16(value);
            if (newValueType == typeof (long)) return Convert.ToInt64(value);
            if (newValueType == typeof (float)) return Convert.ToSingle(value);

            if (newValueType == typeof (uint)) return Convert.ToUInt32(value);
            if (newValueType == typeof (ushort)) return Convert.ToUInt16(value);
            if (newValueType == typeof (ulong)) return Convert.ToUInt64(value);
            if (newValueType == typeof (char)) return Convert.ToChar(value);

            if (newValueType.IsEnum && valueType == typeof(string))
            {
                return Enum.Parse(newValueType, Convert.ToString(value));
            }

            if (newValueType.IsEnum)
            {
                return Convert.ToInt32(value);
            }

            if (valueType == typeof(DateTime) && newValueType == typeof(string))
            {
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
                

            if (valueType == typeof(string) && newValueType == typeof(DateTime)) return Convert.ToDateTime(value);

            throw new ArgumentException($"不支持类型{valueType.Name}转换公共类型{newValueType.Name}");
        }


        /// <summary>
        /// 从数据实体数据库中更新模型数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity">实体对象</param>
        public static void UpdateModelFromEntity<T1, T2>(T1 model, T2 entity) where T1 : ModelBase
        {

            if (model == null) throw new ArgumentNullException("update model is  null");
            if (entity == null) throw new ArgumentNullException("update from entity is null");

            var modelType = typeof (T1);
            var entityType = typeof (T2);
          
            var modelPropertyArray = modelType.GetProperties();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyAttr =
                    (ValuePropertyAttr)
                        modelProperty.GetCustomAttributes(typeof (ValuePropertyAttr), false).FirstOrDefault();
                if (modelPropertyAttr?.Ignore == true) continue;

                var entityPropertyName = string.IsNullOrEmpty(modelPropertyAttr?.EntityPropertyName)
                    ? modelProperty.Name
                    : modelPropertyAttr.EntityPropertyName;

                var entityProperty = entityType.GetProperty(entityPropertyName);
                if (entityProperty == null)
                    throw new Exception($"{entityType.Name} 对象，不存在属性{entityPropertyName},无法进行属性值转换");

                var entityValue = entityProperty.GetValue(entity, null);
                var modelPropertyValue = ToCommonValue(entityValue, entityProperty.PropertyType,
                    modelProperty.PropertyType, modelPropertyAttr?.DefaultValue);

                modelProperty.SetValue(model, modelPropertyValue, null);
            }
        }

        /// <summary>
        /// 根据模型更新模型的属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="updateModel"></param>
        public static void UpdateModelFromModel<T>(T model, T updateModel) where T : ModelBase
        {
            var modelPropertyArray = typeof(T).GetProperties();
            foreach (var modelProperty in modelPropertyArray)
            {
                var propertyValue = modelProperty.GetValue(updateModel, null);
                modelProperty.SetValue(model, propertyValue, null);
            }
        }

        /// <summary>
        ///  将model属性值设置为实体类的属性值
        /// </summary>
        /// <typeparam name="T1">每张表单类型</typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static T2 ModelToEntity<T1,T2>(T1 model) where T1 : ModelBase where  T2 : new()
        {
            var modelPropertyArray = typeof(T1).GetProperties();

            var entity = new T2();
            var entityType = typeof(T2);

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyValue = modelProperty.GetValue(model, null);

                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();

                if (modelPropertyAttr?.Ignore == true) continue;

                var entityPropertyName = string.IsNullOrEmpty(modelPropertyAttr?.EntityPropertyName)
                    ? modelProperty.Name
                    : modelPropertyAttr.EntityPropertyName;

                var entityProperty = entityType.GetProperty(entityPropertyName);
                if (entityProperty == null) throw new Exception($"{ entityType.Name}对象，不存在属性{entityPropertyName},无法进行属性值转换");
                var entityValue = ToCommonValue(modelPropertyValue, modelProperty.PropertyType, entityProperty.PropertyType, modelPropertyAttr?.DefaultValue);

                entityProperty.SetValue(entity, entityValue, null);
            }

            return entity;
        }
        /// <summary>
        ///  将model属性值设置为实体类的属性值
        /// </summary>
        /// <typeparam name="T1">每张表单类型</typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static T2 EntityToModel<T1, T2>(T1 entity) where T2 : ModelBase, new()
        {
            var entityType = typeof(T1);

            var modelPropertyArray = typeof(T2).GetProperties();
            var model = new T2();

            foreach (var modelProperty in modelPropertyArray)
            {
                var modelPropertyValue = modelProperty.GetValue(model, null);

                var modelPropertyAttr = (ValuePropertyAttr)modelProperty.GetCustomAttributes(typeof(ValuePropertyAttr), false).FirstOrDefault();

                if (modelPropertyAttr?.Ignore == true) continue;

                var entityPropertyName = string.IsNullOrEmpty(modelPropertyAttr?.EntityPropertyName)
                    ? modelProperty.Name
                    : modelPropertyAttr.EntityPropertyName;

                var entityProperty = entityType.GetProperty(entityPropertyName);
                if (entityProperty == null) throw new Exception($"{ entityType.Name}对象，不存在属性{entityPropertyName},无法进行属性值转换");
                var entityValue = ToCommonValue(modelPropertyValue, modelProperty.PropertyType, entityProperty.PropertyType, modelPropertyAttr?.DefaultValue);

                entityProperty.SetValue(entity, entityValue, null);
            }

            return model;
        }
    }
}


