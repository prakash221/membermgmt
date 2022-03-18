using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class BranchModel
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchCity { get; set; }
        public string BranchDistrict { get; set; }
        public string BranchProvinceState { get; set; }
        public string BranchCountry { get; set; }
        public string BranchPhoneNumber { get; set; }
        public string BranchEmail { get; set; }
        public Nullable<int> OrganizationLevelID { get; set; }
        public string OrganizationLevelName { get; set; }
    }
}
