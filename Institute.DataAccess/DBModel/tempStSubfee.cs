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
    
    public partial class tempStSubfee
    {
        public string TransactionID { get; set; }
        public string Customer { get; set; }
        public string CustomerID { get; set; }
        public string ReferenceCode { get; set; }
        public string BillID { get; set; }
        public string CategoryCode { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public bool IsSettled { get; set; }
        public Nullable<short> noOfItems { get; set; }
        public string Details { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    }
}
