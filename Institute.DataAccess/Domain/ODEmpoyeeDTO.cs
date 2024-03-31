using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class ODEmpoyeeDTO
    {
        public int SystemId { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
    }
}
