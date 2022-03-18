//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int TransactionID { get; set; }
        public Nullable<int> TransactionTypeID { get; set; }
        public Nullable<int> DonorID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<decimal> TransactionAmount { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Remarks { get; set; }
    
        public virtual Donor Donor { get; set; }
        public virtual Member Member { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}