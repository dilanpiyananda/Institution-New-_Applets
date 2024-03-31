using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class EmpoyeePaymentSummaryDTO
    {
        public int TeacherSummaryId { get; set; }
        public string Code { get; set; }
        public string EnrollementId { get; set; }
        public decimal? TeacherAmount { get; set; }
        public DateTime? Date { get; set; }
    }
}
