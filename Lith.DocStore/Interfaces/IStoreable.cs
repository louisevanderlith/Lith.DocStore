using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Interfaces
{
    public interface IStoreable
    {
        Guid ID { get; set; }

        DateTime DateCreated { get; set; }

        bool IsDeleted { get; set; }
    }
}
