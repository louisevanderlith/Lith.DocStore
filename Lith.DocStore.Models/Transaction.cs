using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class Transaction : BaseRecord
    {
        public bool IsExpense { get; set; }

        public Shop Shop { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
