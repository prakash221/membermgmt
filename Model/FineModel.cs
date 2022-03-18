using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class FineModel
    {
        public int FineID { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public string DesignationName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> OrganizationLevelID { get; set; }
        public string OrganizationLevelName { get; set; }
        public string Remarks { get; set; }
    }
}
