using Lith.DocStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public abstract class BaseRecord : IStoreable
    {
        public Guid ID { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
