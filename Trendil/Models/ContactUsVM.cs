using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trendil.Models
{
    public class ContactUsVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Success { get; set; }
    }
}