using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
  public  interface ITransationTypeService
    {
        bool Save(TransationTypeModel Model);
        bool Update(TransationTypeModel Model);
        bool Delete(int TransactionTypeID);
        List<TransationTypeModel> ListAllData();
        TransationTypeModel GetTransactionTypeById(int TransactionTypeID);
    }
}
