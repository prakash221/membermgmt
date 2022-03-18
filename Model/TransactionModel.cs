using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class TransactionModel
    {
        public int TransactionID { get; set; }
        public Nullable<int> TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public Nullable<int> DonorID { get; set; }
        public string DonorName { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> TransactionAmount { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Remarks { get; set; }
    }
}
