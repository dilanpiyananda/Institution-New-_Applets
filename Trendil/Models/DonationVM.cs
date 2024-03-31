using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trendil.Models
{
    public class DonationVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UploadFileName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public HttpPostedFileBase File { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Success { get; set; }
    }
}