using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IDonorService
    {
        bool Save(DonorModel Model);
        bool Update(DonorModel Model);
        bool Delete(int DonorID);
        List<DonorModel> ListAllData();
        DonorModel GetDonorById(int DonorID);
    }
}
