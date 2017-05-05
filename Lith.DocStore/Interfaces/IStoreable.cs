using System;

namespace Lith.DocStore.Interfaces
{
    public interface IStoreable
    {
        Guid ID { get; set; }

        DateTime DateCreated { get; set; }

        bool IsDeleted { get; set; }
    }
}
