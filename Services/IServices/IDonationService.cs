using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IDonationService
    {
        bool SaveM(DonationModel Model);
        bool UpdateM(DonationModel Model);
        bool SaveD(DonationModel Model);
        bool UpdateD(DonationModel Model);
        bool Delete(int DonationID);
        List<DonationModel> ListAllDataM();
        List<DonationModel> ListAllDataD();
        DonationModel GeDotionById(int DonationID);
    }
}
