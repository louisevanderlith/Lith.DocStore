using System;

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
