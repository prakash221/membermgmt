using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
   public interface IMemberService
    {
        bool Save(MemberModel Model);
        bool Update(MemberModel Model);
        bool Delete(int MemberD);
        List<MemberModel> ListAllData();
        MemberModel GetMemberById(int MemberID);
    }
}
