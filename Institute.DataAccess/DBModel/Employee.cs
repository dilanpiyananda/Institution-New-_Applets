//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Institute.DataAccess.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int SystemID { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Nullable<int> JobCatergoryCode { get; set; }
        public bool IsFullTime { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNo { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string AddressLine { get; set; }
        public string TelephoneNo { get; set; }
        public string email { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> UpdateByUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Category { get; set; }
        public string InstituteID { get; set; }
        public byte[] Pic { get; set; }
        public Nullable<decimal> BasicSalary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoginStatus { get; set; }
    }
}