using Lith.DocStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lith.DocStore
{
    public class Manager
    {
        private readonly IHelpModels modelHelper;

        public Manager(IHelpModels modelHelper)
        {
            this.modelHelper = modelHelper;
        }

        public Guid Save<T>(T model) where T : IStoreable
        {
            return Save(model, true);
        }

        private Guid Save<T>(T model, bool allignRelations) where T : IStoreable
        {
            AssignKey(model);

            if (allignRelations)
            {
                AllignRelationships(model);
            }

            var keyHolder = new KeyForge(model.GetType().Name, model.ID);
            var data = modelHelper.Stringify(model);

            keyHolder.SubmitKey(data);

            return model.ID;
        }

        public T Load<T>(Guid id)
        {
            var modelName = typeof(T).Name;
            var keyHolder = new KeyForge(modelName, id);

            var data = keyHolder.LoadKeyData();

            return modelHelper.DeStringify<T>(data);
        }

        private static void AssignKey(IStoreable model)
        {
            if (model.ID == Guid.Empty)
            {
                model.ID = Guid.NewGuid();
                model.DateCreated = DateTime.Now;
                model.IsDeleted = false;
            }
        }

        private void AllignRelationships<T>(T model)
        {
            var properties = model.GetType().GetProperties();

            foreach (var property in properties)
            {
                var proptype = property.PropertyType;
                var propValue = property.GetValue(model);

                if (typeof(IEnumerable<IStoreable>).IsAssignableFrom(proptype))
                {
                    foreach (var item in (IEnumerable<IStoreable>)propValue)
                    {
                        Save(item, false);
                    }
                }

                if (typeof(IStoreable).IsAssignableFrom(proptype) && propValue != null)
                {
                    Save((IStoreable)propValue, false);
                }
            }
        }
    }
}
