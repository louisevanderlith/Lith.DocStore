using Lith.DocStore.Interfaces;
using System.Collections.Generic;

namespace Lith.DocStore
{
    public interface IStoreContext
    {
        List<IStoreable> Entities { get; }
        IHelpModels ModelHelper { get; }

        void Dispose();
        void Save();
    }
}