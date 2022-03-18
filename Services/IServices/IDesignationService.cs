using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IDesignationService
    {
        bool Save(DesignationModel Model);
        bool Update(DesignationModel Model);
        bool Delete(int DesignationID);
        List<DesignationModel> ListAllData();
        DesignationModel GetDesignationById(int DesignationID);
    }
}
