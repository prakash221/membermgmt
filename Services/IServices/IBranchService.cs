using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IBranchService
    {
        bool Save(BranchModel Model);
        bool Update(BranchModel Model);
        bool Delete(int BranchID);
        List<BranchModel> ListAllData();
        BranchModel GetBranchById(int BranchID);
    }
}
