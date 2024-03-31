using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Domain
{
    public static class TimeTableStatus
    {
        public static string Cancel { get; } = "cancel";
        public static string Sheduled { get; } = "scheduled";
    }
}
