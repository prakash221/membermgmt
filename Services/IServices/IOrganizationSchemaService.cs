using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
   public interface IOrganizationSchemaService
    {
        bool Save(OrganizationSchemaModel Model);
        bool Update(OrganizationSchemaModel Model);
        bool Delete(int SchemaObjectID);
        List<OrganizationSchemaModel> ListAllData();
        OrganizationSchemaModel GetOrganizationSchemaById(int SchemaObjectID);
    }
}
