using Institute.DataAccess.DBModel;
using Institute.DataAccess.Domain;
using Institute.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.DataAccess.Repository
{
    public class TimeTableRepository:ITimeTableRepository
    {

        public List<TimeTableDTO> GetSceduledTimeTable()
        {
            using (nobleEntities db= new nobleEntities())
            {
                var timeTable = db.cancel_timetable.Where(d => d.status.ToLower() == TimeTableStatus.Sheduled).ToList();
                return TimeTableGetLatest(timeTable);
            }
            return null;
        }

        private List<TimeTableDTO> TimeTableGetLatest(List<cancel_timetable> timeTable)
        {
            if(timeTable != null && timeTable.Count() > 0)
            {
                DateTime todayMidnight = DateTime.Today;
                todayMidnight = todayMidnight.AddHours(12);
                var timetablegroup = timeTable.Where(d=> d.date >= todayMidnight).GroupBy(d => new { d.employee,d.Class,d.subject }).ToList();
                return timetablegroup.Select(d => new TimeTableDTO
                {
                    Teacher = d.FirstOrDefault().Teacher,
                    Type = d.OrderByDescending(k => k.cid).FirstOrDefault().type,
                    Class = d.Key.Class,
                    EmpolyeeId = d.Key.employee,
                    Subject = d.Key.subject,
                    Date = d.OrderByDescending(k => k.cid).FirstOrDefault().date,
                    Time = d.OrderByDescending(k => k.cid).FirstOrDefault().time,
                    Id = d.FirstOrDefault().cid,
                    UpdatedDate = d.OrderByDescending(k => k.cid).FirstOrDefault().updated_date,
                    TeacherImage = GetTeacherImage(d.Key.employee),
                    TeacherObj = GetTeacherObj(d.Key.employee)

                }).ToList();

            }

            return null;
        }

        private TeacherDTO GetTeacherObj(string teacherId)
        {
            using (nobleEntities db = new nobleEntities())
            {
                var timeTable = db.Employees.Where(d => d.EmployeeID.ToLower() == teacherId.ToLower()).ToList();
                if (timeTable != null && timeTable.Count() > 0)
                {
                    return timeTable.Select(d => new TeacherDTO()
                    {
                        TeacherName = d.Name,
                        Tel = d.TelephoneNo,
                        Email = d.email,
                        Image = d.Pic,
                        EmpolyeeId = d.email
                    }).FirstOrDefault();
                }
            }
            return null;
        }
        private byte[] GetTeacherImage(string teacherId)
        {
            using (nobleEntities db = new nobleEntities())
            {
                var teacher = db.Employees.Where(d => d.EmployeeID.ToLower() == teacherId.ToLower()).FirstOrDefault();

                if (teacher != null) return teacher.Pic;
            }
            return null;
        }

        public List<TimeTableDTO> GetCanceledTimeTable()
        {
            using (nobleEntities db = new nobleEntities())
            {
                var timeTable = db.cancel_timetable.Where(d => d.status.ToLower() == TimeTableStatus.Cancel).ToList();
                return TimeTableGetLatest(timeTable);
            }
            return null;
        }

        public List<TeacherDTO> GetTeachers()
        {
            using (nobleEntities db = new nobleEntities())
            {
                var timeTable = db.Employees.Where(d => d.Category.ToLower() == "teacher").ToList();
                if(timeTable != null && timeTable.Count() > 0)
                {
                    return timeTable.Select(d => new TeacherDTO()
                    {
                        TeacherName = d.Name,
                        Tel = d.TelephoneNo,
                        Email = d.email,
                        Image = d.Pic,
                        EmpolyeeId = d.email
                    }).ToList();
                }
            }
            return null;
        }

        public List<EventDTO> GetEvent()
        {
            using (nobleEntities db = new nobleEntities())
            {
                var events = db.Events.Where(d => d.ExpireDate >= DateTime.Now && d.IsDeleted == false).ToList();
                if (events != null && events.Count() > 0)
                {
                    return events.Select(d => new EventDTO()
                    {
                        Id = d.Id,
                        Description = d.Description,
                        IsDeleted = d.IsDeleted,
                        Image = d.Image,
                        ExpireDate = d.ExpireDate,
                        Title = d.Title
                    }).ToList();
                }
            }
            return null;
        }

        public TeacherPaymentDTO GetTeacherPaymentDTO(string teacherId)
        {
            var singleTeacher = GetTeacherObj(teacherId);
            if(singleTeacher != null)
            {
                return new TeacherPaymentDTO()
                {
                    EmployeepaymentSummary = GetTeacherPaymentSummary(teacherId),
                    TeacherAdvancedTransaction = GetTeacherAdvancedTransaction(teacherId),
                    TeacherOD = GetTeacherOD(teacherId),
                    TeacherId = teacherId,
                    TeacherImage = singleTeacher.Image,
                    TeacherName = singleTeacher.TeacherName,
                   
                };
            }
            return null;
            
        }

        private List<EmpoyeePaymentSummaryDTO> GetTeacherPaymentSummary(string teacherId)
        {
            int month = DateTime.Now.Month - 1;
            DateTime fromDate = new DateTime(DateTime.Now.Year, month, 1);
            DateTime todate = new DateTime(DateTime.Now.Year, (month + 1), 1);

            using (nobleEntities db = new nobleEntities())
            {
                var payments = db.TeacherPaymentSummeries.Where(d => d.TeacherCode.ToLower() == teacherId.ToLower() && d.CategoryCode == "CA19" && d.SummeryDate >= fromDate && d.SummeryDate < todate).Select(d => new EmpoyeePaymentSummaryDTO()
                {
                    Code = d.TeacherCode,
                    TeacherAmount = d.TeacherAmount,
                    TeacherSummaryId = d.TeacherSummeryId,
                    Date = d.SummeryDate,
                    EnrollementId = d.EntrollmentID,
                }).ToList();
                return payments;
            }
        }

        private List<TransactionDTO> GetTeacherAdvancedTransaction(string teacherId)
        {
            int month = DateTime.Now.Month - 1;
            DateTime fromDate = new DateTime(DateTime.Now.Year, month, 1);
            DateTime todate = new DateTime(DateTime.Now.Year, (month + 1), 1);

            using (nobleEntities db = new nobleEntities())
            {
                var advancedPayment = db.Transactions.Where(d => d.EmployeeID.ToLower() == teacherId.ToLower() && d.CategoryCode == "CA20" && d.PaymentDate >= fromDate && d.PaymentDate < todate).Select(d => new TransactionDTO()
                {
                    Amount = d.Amount,
                    PaidDate = d.PaymentDate,
                    Reference = d.Reference,
                }).ToList();

                return advancedPayment;
            }
        }

        private ODEmpoyeeDTO GetTeacherOD(string teacherId)
        {
            using (nobleEntities db = new nobleEntities())
            {
                var odPayment = db.OD_Employees.Where(d => d.EmployeeID.ToLower() == teacherId.ToLower() ).Select(d => new ODEmpoyeeDTO()
                {
                    Amount = d.ODAmount,
                    Name = d.Name,
                    TeacherId = d.EmployeeID,
                    SystemId = d.SystemID,
                }).FirstOrDefault();

                return odPayment;
            }
        }
    }    
}
