using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
 public   interface IMembershipFeeService
    {
        bool Save(MembershipFeeModel Model);
        bool Update(MembershipFeeModel Model);
        bool Delete(int MembershipFeeID);
        List<MembershipFeeModel> ListAllData();
        MembershipFeeModel GetMembershipFeeById(int MembershipFeeID);
    }
}
