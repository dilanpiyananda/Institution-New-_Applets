using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class TeacherPaymentDTO
    {
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public byte[] TeacherImage { get; set; }
        public ODEmpoyeeDTO TeacherOD { get; set; }
        public List<EmpoyeePaymentSummaryDTO> EmployeepaymentSummary { get; set; }
        public List<TransactionDTO> TeacherAdvancedTransaction { get; set; }
        public decimal TeacherEarning { get; set; }
        public decimal ODAmount { get; set; }
        public decimal Advnaced { get; set; }
        public decimal Total { get; set; }
    }
}
