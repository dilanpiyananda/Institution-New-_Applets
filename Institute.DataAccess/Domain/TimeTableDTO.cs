using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public class TimeTableDTO
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Subject { get; set; }
        public string EmpolyeeId { get; set; }
        public byte[] TeacherImage { get; set; }
        public TeacherDTO TeacherObj { get; set; }
    }
}
