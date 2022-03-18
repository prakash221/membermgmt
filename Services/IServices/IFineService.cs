using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
   public interface IFineService
    {
        bool Save(FineModel Model);
        bool Update(FineModel Model);
        bool Delete(int FineID);
        List<FineModel> ListAllData();
        FineModel GetFineById(int FineID);
    }
}
