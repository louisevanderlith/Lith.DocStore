using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class Account : BaseRecord
    {
        public string Number { get; set; }

        public string Bank { get; set; }

        public Shop Shop { get; set; }
    }
}
