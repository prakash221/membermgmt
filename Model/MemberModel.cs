using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MemberModel
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> OccupationID { get; set; }
        public string OccuptionName { get; set; }
        public Nullable<int> BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
