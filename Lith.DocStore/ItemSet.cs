﻿using Lith.DocStore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lith.DocStore
{
    public class ItemSet<T> : IEnumerable<T>, IEnumerable, IDisposable where T : class, IStoreable
    {
        private readonly IStoreContext context;
        private readonly KeyRing keyRing;

        public ItemSet(IStoreContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
            this.keyRing = new KeyRing();
            this.context.Entities.AddRange(GetFreshItems());
        }

        public IEnumerator<T> GetEnumerator()
        {
            var itemSet = from a in context.Entities
                          where a.GetType() == typeof(T)
                          select (T)a;

            return itemSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T model)
        {
            context.Entities.Add(model);
        }

        public void AddRange(IEnumerable<T> models)
        {
            foreach (var model in models)
            {
                context.Entities.Add(model);
            }
        }

        public T Find(Guid ID)
        {
            var result = context.Entities.FirstOrDefault(a => !a.IsDeleted && a.ID == ID);

            if (result == null)
            {
                var ctxResult = context.Entities.FirstOrDefault(a => !a.IsDeleted && a.ID == ID);

                if (ctxResult is T)
                {
                    result = ctxResult as T;
                }
            }

            return (T)result;
        }

        private List<T> GetFreshItems()
        {
            var manager = new Manager(context.ModelHelper);
            var sectionName = typeof(T).Name;
            var onRingKeys = keyRing.GetKeysInSection(sectionName);
            var onRAMKeys = context.Entities.Any() ? context.Entities.Select(s => s.ID) : new List<Guid>();

            // We don't wan't items we already have in memory, they could have been updated.
            return (from a in onRingKeys
                    where !onRAMKeys.Contains(a.ID)
                    select manager.Load<T>(a.ID)).ToList();
        }

        public void Dispose()
        {
            keyRing.Dispose();
        }
    }
}
