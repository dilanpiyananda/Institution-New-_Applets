using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Trendil.Helper
{
    public class MembershipUtilities
    {
        /// <summary>
        /// Create authentication cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="version"></param>
        /// <param name="name"></param>
        /// <param name="persist"></param>
        /// <param name="isseuDate"></param>
        /// <param name="expireDate"></param>
        /// <param name="data"></param>
        /// <param name="userName"></param>
        public void CreateAuthCookie(string cookieName, int version, string name, bool persist, DateTime isseuDate, DateTime expireDate, string data, string userName)
        {

            FormsAuthenticationTicket ticket = CreateAuthTicket(version, name, persist, isseuDate, expireDate, data);
            string coockieVal = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, coockieVal);
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        /// <summary>
        /// Create authentication ticket
        /// </summary>
        /// <param name="version"></param>
        /// <param name="name"></param>
        /// <param name="persist"></param>
        /// <param name="isseuDate"></param>
        /// <param name="expireDate"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private FormsAuthenticationTicket CreateAuthTicket(int version, string name, bool persist, DateTime isseuDate, DateTime expireDate, string data)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(version, name, isseuDate, expireDate, persist, data);
            return ticket;

        }

        //---------------------------------Get Logged Cookies Values ----------------------------
        public string GetCookieValueUserID()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Values[0]);
                string[] data = ticket.UserData.Split('~');

                return data[0];
            }
            return "";
        }

        public string GetCookieValueUserName()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Values[0]);
                string[] data = ticket.UserData.Split('~');

                return data[1];
            }
            return "";
        }

        public string GetCookieValueCompanyID()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Values[0]);
                string[] data = ticket.UserData.Split('~');

                return data[2];
            }
            return "";
        }
        public string GetCookieValueIsSuperUser()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Values[0]);
                string[] data = ticket.UserData.Split('~');

                return data[3];
            }
            return "";
        }

        public string GetCookieValueSecurityGroup()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Values[0]);
                string[] data = ticket.UserData.Split('~');

                return data[4];
            }
            return "";
        }
    }
}