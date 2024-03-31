using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class TransactionDTO
    {
        public string Reference { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
