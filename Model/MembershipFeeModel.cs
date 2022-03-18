using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class MembershipFeeModel
    {
        public int MemberShipFeeID { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public decimal Amount { get; set; }
        public int OrganizationLevelID { get; set; }
        public string OrganizationLevelName { get; set; }
        public string Remarks { get; set; }
    }
}
