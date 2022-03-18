using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IAchievementService
    {
        bool Save(AchievementModel Model);
        bool Update(AchievementModel Model);
        bool Delete(int AchievementID);
        List<AchievementModel> ListAllData();
        AchievementModel GetAchievementById(int AchievementID);
    }
}
