using Institute.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Repository.Interface
{
    public interface ITimeTableRepository
    {
        List<TimeTableDTO> GetSceduledTimeTable();

        List<TimeTableDTO> GetCanceledTimeTable();

        List<TeacherDTO> GetTeachers();
        List<EventDTO> GetEvent();

        TeacherPaymentDTO GetTeacherPaymentDTO(string teacherId);
    }
}
