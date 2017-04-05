using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class Summary : BaseRecord
    {
        public double TotalExpenses { get; set; }

        public double TotalIncome { get; set; }

        public double Remainder
        {
            get
            {
                return TotalIncome - TotalExpenses;
            }
        }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
