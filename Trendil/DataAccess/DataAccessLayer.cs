using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using Trendil.Helper;
using Trendil.Models;

namespace Trendil.DataAccess
{
    public class DataAccessLayer:IDataAccessLayer
    {
        private static string ToFormat24h(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public ContactUsVM SaveContactUs(ContactUsVM contact)
        {
            //var date = DateTime.TryParse("2022-10-15 1:00:00 PM", out DateTime t);
            //var r = ToFormat24h(t);
            try
            {
                string sql = "INSERT INTO `ContactUs` (`Id`, `FirstName`, `LastName`, `Email`, `Comment`, `CreateDate`)" +
                    " VALUES (NULL, '" + contact.FirstName + "', '" + contact.LastName + "', '" + contact.Email + "', '" + contact.Comment + "','"+ ToFormat24h(contact.CreateDate) + "')";

                DbHandler.ConnectionSet();
                
                contact.Success = DbHandler.NonExcute(sql); 
                return contact;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public DonationVM SaveDonation(DonationVM donation)
        {
            try
            {
                string sql = "INSERT INTO `Donation` (`Id`, `FirstName`, `LastName`, `Email`, `Country`, `Mobile`, `UploadFileName`, `CreateDate`)"+
                    "VALUES (NULL, '"+donation.FirstName+ "', '" + donation.LastName + "', '" + donation.Email + "', '" + donation.Country + "','" + donation.Mobile + "', '" + donation.UploadFileName + "', '" + ToFormat24h(donation.CreateDate) + "')";

                DbHandler.ConnectionSet();
                
                donation.Success = DbHandler.NonExcute(sql); 
                return donation;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUser(LoginVM login)
        {
            try
            {
                User user = new User();
                DbHandler.ConnectionSet();
                string sql = "SELECT * FROM `User` WHERE IsActive = 1 AND Email ='"+login.Email+"' AND Password = '"+login.Password+"' ";
                DataTable table = DbHandler.Get(sql);
                if(table != null && table.Rows.Count > 0)
                {
                   
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        user.Id = Convert.ToInt32(table.Rows[i]["Id"]);
                        user.UserName = table.Rows[i]["UserName"].ToString();
                        user.Password = table.Rows[i]["Password"].ToString();
                        user.Email = table.Rows[i]["Email"].ToString();
                        user.IsActive = Convert.ToBoolean(table.Rows[i]["IsActive"]);
                    }
                    return user;
                }
                return null;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DonationVM> GetDonations()
        {
            try
            {
                List<DonationVM> donationsList = new List<DonationVM>();
                DbHandler.ConnectionSet();
                string sql = "SELECT * FROM `Donation`";
                DataTable table = DbHandler.Get(sql);
                if (table != null && table.Rows.Count > 0)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DonationVM donation = new DonationVM()
                        {
                            Id = Convert.ToInt32(table.Rows[i]["Id"]),
                            Country = table.Rows[i]["Country"].ToString(),
                            Mobile = table.Rows[i]["Mobile"].ToString(),
                            CreateDate = Convert.ToDateTime(table.Rows[i]["CreateDate"].ToString()),
                            Email = table.Rows[i]["Email"].ToString(),
                            FirstName = table.Rows[i]["FirstName"].ToString(),
                            LastName = table.Rows[i]["LastName"].ToString(),
                            UploadFileName = table.Rows[i]["UploadFileName"].ToString()
                        };
                        donationsList.Add(donation);
                        
                    }
                    
                }
                if (donationsList != null && donationsList.Count() > 0) donationsList = donationsList.OrderByDescending(d => d.CreateDate).ToList();
                return donationsList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ContactUsVM> GetContacts()
        {
            try
            {
                List<ContactUsVM> conatactUsList = new List<ContactUsVM>();
                DbHandler.ConnectionSet();
                string sql = "SELECT * FROM `ContactUs`";
                DataTable table = DbHandler.Get(sql);
                if (table != null && table.Rows.Count > 0)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        ContactUsVM conatact = new ContactUsVM()
                        {
                            Id = Convert.ToInt32(table.Rows[i]["Id"]),
                            Comment = table.Rows[i]["Comment"].ToString(),
                            CreateDate = Convert.ToDateTime(table.Rows[i]["CreateDate"].ToString()),
                            Email = table.Rows[i]["Email"].ToString(),
                            FirstName = table.Rows[i]["FirstName"].ToString(),
                            LastName = table.Rows[i]["LastName"].ToString(),
                        };
                        conatactUsList.Add(conatact);

                    }

                }

                if (conatactUsList != null && conatactUsList.Count() > 0) conatactUsList = conatactUsList.OrderByDescending(d => d.CreateDate).ToList();
                return conatactUsList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}