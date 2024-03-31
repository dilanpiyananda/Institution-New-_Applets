using Institute.Business.Services;
using Institute.Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Trendil.Common;
using Trendil.DataAccess;
using Trendil.Helper;
using Trendil.Models;

namespace Trendil.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataAccessLayer _dataAcc = new DataAccessLayer();
        private readonly ITimeTableService _timeTableServ = new TimeTableService();

        [Route("Home-Index")]
        public ActionResult Index()
        {
            HomeVM model = new HomeVM();
            var teacherModel = _timeTableServ.GetTeachers();
            if (teacherModel != null && teacherModel.Count() > 0)
            {
                model.Teachers= teacherModel.OrderBy(t => Guid.NewGuid()).Take(4).ToList();
            }
            
            var scheduleTimeTable = _timeTableServ.GetSceduledTimeTable();
            if(scheduleTimeTable != null && scheduleTimeTable.Count() > 0)
            {
                model.TimeTables = scheduleTimeTable.OrderByDescending(d => d.Id).Take(4).ToList();
            }

            return View(model);
        }

        public ActionResult Classes()
        {
            return View();
        }

        public ActionResult knowldgeSharing()
        {
            return View();
        }

        public ActionResult CommunityEmpowerment()
        {
            return View();
        }

        public ActionResult OurTeachers()
        {
            var model = _timeTableServ.GetTeachers();
            return View(model);
        }

        public ActionResult Project(ProejectEnum projectEnum)
        {
            return View(projectEnum);
        }
        
        public ActionResult FutureProject(FutureProjectEnum futureProejctEnum)
        {
            ViewBag.FutureProjectEnum = futureProejctEnum;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OurProduct()
        {
            return View();
        }

        public ActionResult Scheduled()
        {
            var model = _timeTableServ.GetSceduledTimeTable();
            return View(model);
        }

        public ActionResult Canceled()
        {
            var model = _timeTableServ.GetCanceledTimeTable();
            return View(model);
        }

        public ActionResult Events()
        {
            var model = _timeTableServ.GetEvent();
            return View(model);
        }

        public ActionResult TeacherSalary(string teacherId)
        {
            var model = _timeTableServ.GetTeacherPaymentDTO(teacherId);
            return View(model);
        }

    }
}