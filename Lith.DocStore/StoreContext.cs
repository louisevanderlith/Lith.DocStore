﻿using Lith.DocStore.Interfaces;
using System;
using System.Collections.Generic;

namespace Lith.DocStore
{
    public class StoreContext : IDisposable, IStoreContext
    {
        private readonly List<IStoreable> entries;
        private readonly IHelpModels modelHelper;

        public StoreContext(IHelpModels modelHelper)
        {
            if (modelHelper == null)
            {
                throw new ArgumentNullException(nameof(modelHelper));
            }

            this.entries = new List<IStoreable>();
            this.modelHelper = modelHelper;

            LoadProperties();
        }

        public IHelpModels ModelHelper
        {
            get
            {
                return this.modelHelper;
            }
        }

        public List<IStoreable> Entities
        {
            get
            {
                return entries;
            }
        }

        public virtual void Save()
        {
            var manager = new Manager(modelHelper);

            foreach (var item in entries)
            {
                manager.Save(item);
            }

            //entries.Clear();
        }

        private void LoadProperties()
        {
            var type = this.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var propertyCtor = property.PropertyType.GetConstructor(new Type[] { typeof(IStoreContext) });

                if (propertyCtor != null)
                {
                    var value = propertyCtor.Invoke(new object[] { this });

                    property.SetValue(this, value);
                }
            }
        }

        public void Dispose()
        {
            entries.Clear();
        }
    }
}
