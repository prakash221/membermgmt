using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IOccuptionService
    {
        bool Save(OccupationModel Model);
        bool Update(OccupationModel Model);
        bool Delete(int OccuptionID);
        List<OccupationModel> ListAllData();
        OccupationModel GetOccuptionById(int OccuptionID);
    }
}
