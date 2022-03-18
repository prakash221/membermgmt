using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
   public interface IDesignationTypeService
    {
        bool Save(DesignationTypeModel Model);
        bool Update(DesignationTypeModel Model);
        bool Delete(int DesignationTypeID);
        List<DesignationTypeModel> ListAllData();
        DesignationTypeModel GetDesignationTypeById(int DesignationTypeID);
    }
}
