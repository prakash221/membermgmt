using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class DesignationModel
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> DesignationTypeID { get; set; }
        public string DesignationTypeName { get; set; }
    }
}
