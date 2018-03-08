using Lith.DocStore.Interfaces;
using System;

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
            AssignKey(model);

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
    }
}
