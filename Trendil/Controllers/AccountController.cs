using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trendil.DataAccess;
using Trendil.Helper;
using Trendil.Models;

namespace Trendil.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDataAccessLayer _dataAcc = new DataAccessLayer();
        // GET: Account
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult PostLogin(LoginVM loginVM)
        {
            var user = _dataAcc.GetUser(loginVM);

            if(user != null)
            {
                string data = user.UserName;
                MembershipUtilities membershipUtilities = new MembershipUtilities();
                membershipUtilities.CreateAuthCookie("myCookie", 1, "myTicket", true, DateTime.Now, DateTime.Now.AddMinutes(100), data, user.UserName);

            }
            else
            {
                loginVM.Error = "Email or Password Incorrect";
                loginVM.Password = "";
                return View(nameof(Index), loginVM);
            }

            return RedirectToAction(nameof(Dashboard));
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Authorize]
        public ActionResult ContactUs()
        {
            var model = _dataAcc.GetContacts();
            return View(model);
        }

        [Authorize]
        public ActionResult Donations()
        {
            var model = _dataAcc.GetDonations();
            return View(model);
        }

        [Authorize]
        public ActionResult DonationDetail(DonationVM donation)
        {
            return View(donation);
        }

        public ActionResult LogOut()
        {
            try
            {
                System.Web.HttpContext.Current.Session["CustomerName"] = null;
                System.Web.Security.FormsAuthentication.SignOut();

            }
            catch
            {

            }
            return RedirectToAction("Index", "Account");
        }

    }
}