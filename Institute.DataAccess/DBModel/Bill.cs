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
    
    public partial class Bill
    {
        public string BillID { get; set; }
        public Nullable<System.DateTime> Dates { get; set; }
        public string StudentID { get; set; }
        public string InstituteID { get; set; }
        public Nullable<decimal> Cash { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> Dues { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> UpdateByUser { get; set; }
        public Nullable<short> MachineId { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string PayMode { get; set; }
        public string CreditCard { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> OffFees { get; set; }
        public string Month { get; set; }
        public string Branch { get; set; }
    }
}
