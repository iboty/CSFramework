using System;

namespace CSFramework.MVVM.Models
{
    public class ModelStruct 
    {
        public ModelStruct()
        {
            InitData();
        }

        private void InitData()
        {
            var structPropertyArray = GetType().GetProperties();
            foreach (var structProperty in structPropertyArray)
            {
                var modelValue = structProperty.GetValue(this, null);
                if (modelValue != null) continue;

                modelValue = Activator.CreateInstance(structProperty.PropertyType);
                structProperty.SetValue(this, modelValue, null);
            }
        }

        //public void SyncFromEntityList<T>(List<T> entityList, Action<T> addEntityHandle, Action<T> modifyEntityHandle) where T : new()
        //{
        //    if(entityList == null || entityList.Count == 0) return;

        //    var structPropertyArray = GetType().GetProperties();

        //    foreach (var structProperty in structPropertyArray)
        //    {
        //        var structPropertyValue = (ModelBase)structProperty.GetValue(this, null);
        //        var entity = entityList.FirstOrDefault(t => structPropertyValue.CheckEqualsKey(t));
        //        if (entity == null)
        //        {
        //            addEntityHandle(structPropertyValue.ToEntity<T>());
        //        }
        //        else
        //        {
        //            structPropertyValue.UpdateFromEntity(entity);
        //        }
        //        structPropertyValue.PropertyChanged += (o, e) => modifyEntityHandle(structPropertyValue.ToEntity<T>());
        //    }
        //}
     
    }
}
