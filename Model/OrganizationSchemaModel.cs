using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class OrganizationSchemaModel
    {
        public int SchemaObjectID { get; set; }
        public string SchemaObjectName { get; set; }
        public string SchemaObjectValue { get; set; }
        public string Remarks { get; set; }
    }
}
