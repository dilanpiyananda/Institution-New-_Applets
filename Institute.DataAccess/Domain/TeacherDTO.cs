using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class TeacherDTO
    {
        public string EmpolyeeId { get; set; }
        public string TeacherName { get; set; }
        public byte[] Image { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
