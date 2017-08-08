using Lith.DocStore.Interfaces;
using System;

namespace Lith.DocStore.Models
{
    public abstract class BaseRecord : IStoreable
    {
        public Guid ID { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
