using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Services.IServices
{
   public interface ITransationService
    {
        bool Save(TransactionModel Model);
        bool Update(TransactionModel Model);
        bool Delete(int TransactionID);
        List<TransactionModel> ListAllData();
        List<TransactionModel> ListAllDataFine();
        List<TransactionModel> ListAllDataDonation();
        List<TransactionModel> ListAllDataFee();
        TransactionModel GetTransactionById(int TransactionID);
    }
}
