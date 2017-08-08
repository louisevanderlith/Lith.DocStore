using Lith.DocStore.Common;
using Lith.DocStore.Interfaces;
using System.Collections.Generic;

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