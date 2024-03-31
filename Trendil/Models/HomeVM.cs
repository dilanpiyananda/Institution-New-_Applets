using Institute.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trendil.Models
{
    public class HomeVM
    {
        public List<TeacherDTO> Teachers { get; set; }
        public List<TimeTableDTO> TimeTables { get; set; }
    }
}