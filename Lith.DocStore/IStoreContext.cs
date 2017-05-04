using System.Collections.Generic;
using Lith.DocStore.Interfaces;
using Lith.DocStore.Common;

namespace Lith.DocStore
{
    public interface IStoreContext
    {
        IList<IStoreable> Entities { get; }
        IHelpModels ModelHelper { get; }

        void Dispose();
        void Save();
    }
}