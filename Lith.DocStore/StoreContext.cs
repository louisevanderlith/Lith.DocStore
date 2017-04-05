using Lith.DocStore.Interfaces;
using Lith.DocStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore
{
    public class StoreContext : IDisposable
    {
        private readonly KeyRing keyRing;
        private readonly IList<IStoreable> setItems;

        public StoreContext()
        {
            this.keyRing = new KeyRing();
            this.setItems = new List<IStoreable>();
        }

        public IList<T> Set<T>() where T : IStoreable
        {
            var items = GetFreshItems<T>();

            foreach (var item in items)
            {
                setItems.Add(item);
            }

            return (from s in setItems
                    where s is T
                    select (T)s).ToList();
        }

        private List<T> GetFreshItems<T>() where T : IStoreable
        {
            var manager = new Manager(new JSONModelHelper());
            var sectionName = typeof(T).Name;
            var onRingKeys = keyRing.GetKeysInSection(sectionName);
            var onRAMKeys = setItems.Select(s => s.ID);

            // We don't wan't items we already have in memory, they could have been updated.
            return (from a in onRingKeys
                    where !onRAMKeys.Contains(a.ID)
                    select manager.Load<T>(a.ID)).ToList();
        }

        public void Add<T>(T model) where T : IStoreable
        {
            setItems.Add(model);
        }

        public void AddRange<T>(IEnumerable<T> models) where T : IStoreable
        {
            foreach (var model in models)
            {
                setItems.Add(model);
            }
        }

        public void Save()
        {
            var manager = new Manager(new JSONModelHelper());

            foreach (var item in setItems)
            {
                manager.Save(item);
            }

            setItems.Clear();
        }

        public void Dispose()
        {
            keyRing.Dispose();
            setItems.Clear();
        }
    }
}
