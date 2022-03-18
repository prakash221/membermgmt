using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IOrganizationLevelService
    {
        bool Save(OrganizationLevelModel Model);
        bool Update(OrganizationLevelModel Model);
        bool Delete(int OrganizationLevelID);
        List<OrganizationLevelModel> ListAllData();
        OrganizationLevelModel GetOrganizationLevelById(int OrganizationLevelID);
    }
}
