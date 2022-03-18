using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IAwardService
    {
        bool Save(AwardModel Model);
        bool Update(AwardModel Model);
        bool Delete(int AwardID);
        List<AwardModel> ListAllData();
        AwardModel GetAwardById(int AwardID);
    }
}
