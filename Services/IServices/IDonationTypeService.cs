using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IDonationTypeService
    {
        bool Save(DonationTypeModel Model);
        bool Update(DonationTypeModel Model);
        bool Delete(int DonationTypeID);
        List<DonationTypeModel> ListAllData();
        DonationTypeModel GetDonationTypeById(int DonationTypeID);
    }
}
