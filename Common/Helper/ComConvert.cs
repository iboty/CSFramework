using System;
using System.ComponentModel;
using System.Management;
using CSFramework.MVVM.Data;

namespace CSFramework.Common.Helper
{
    public static class ComConvert
    {
        public static T ManagementObjectToEntity<T>(ManagementObject mObj) where T : new()
        {
            var entity = new T();
            var entityProperties = typeof(T).GetProperties();

            foreach (var entityProperty in entityProperties)
            {
                var sourceValue = mObj[entityProperty.Name];
                entityProperty.SetValue(entity, sourceValue);
            }

            return entity;
        }

        internal static RunResult ExceptionToRunResult(Exception e)
        {
            return e == null ? RunResult.Success : RunResult.Fault;
        }

       
    }
}