using Institute.Business.Services.Interface;
using Institute.DataAccess.Domain;
using Institute.DataAccess.Repository;
using Institute.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.Business.Services
{
    public class TimeTableService:ITimeTableService
    {
        private readonly ITimeTableRepository _timeTable = new TimeTableRepository();
        public List<TimeTableDTO> GetSceduledTimeTable()
        {
            return _timeTable.GetSceduledTimeTable();
        }

        public List<TimeTableDTO> GetCanceledTimeTable()
        {
            return _timeTable.GetCanceledTimeTable();
        }

        public List<TeacherDTO> GetTeachers()
        {
            return _timeTable.GetTeachers();
        }

        public List<EventDTO> GetEvent()
        {
            return _timeTable.GetEvent();
        }

        public TeacherPaymentDTO GetTeacherPaymentDTO(string teacherId)
        {
            var teacherPayment = _timeTable.GetTeacherPaymentDTO(teacherId);
            if(teacherPayment != null)
            {
                if(teacherPayment.TeacherOD != null && teacherPayment.TeacherOD.Amount != null)
                {
                    teacherPayment.ODAmount = Convert.ToDecimal( teacherPayment.TeacherOD.Amount);
                }
                
                if(teacherPayment.EmployeepaymentSummary != null && teacherPayment.EmployeepaymentSummary.Count() > 0)
                {
                    teacherPayment.TeacherEarning = Convert.ToDecimal( teacherPayment.EmployeepaymentSummary.Where(d=> d.TeacherAmount != null).Sum(d => d.TeacherAmount));
                }

                if(teacherPayment.TeacherAdvancedTransaction != null && teacherPayment.TeacherAdvancedTransaction.Count() > 0)
                {
                    teacherPayment.Advnaced = Convert.ToDecimal(teacherPayment.TeacherAdvancedTransaction.Where(d => d.Amount != null).Sum(d => d.Amount));
                }

                teacherPayment.Total = teacherPayment.TeacherEarning - teacherPayment.ODAmount - teacherPayment.Advnaced;
            }

            return teacherPayment;
        }
    }
}
