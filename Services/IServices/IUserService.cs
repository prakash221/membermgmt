using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface IUserService
    {
        UserModel CheckAuthorization(UserModel Model);
        bool Save(UserModel Model);
        bool Update(UserModel Model);
        bool Delete(int UserID);
        List<UserModel> ListAllData();
        UserModel GetUserById(int UserID);
    }
}
