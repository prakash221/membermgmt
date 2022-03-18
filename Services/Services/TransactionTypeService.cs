using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Services.Services;
using Services.IServices;
using Model;

namespace Services.Services
{
    public class TransactionTypeService : ITransationTypeService
    {
        public bool Delete(int TransactionTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.TransactionTypes.Where(a => a.TransactionTypeID == TransactionTypeID).FirstOrDefault();
                    _context.TransactionTypes.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public TransationTypeModel GetTransactionTypeById(int TransactionTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.TransactionTypes.Where(a => a.TransactionTypeID == TransactionTypeID).Select(a => new TransationTypeModel()
                    {
                        TransactionTypeID = a.TransactionTypeID,
                        TransactionTypeName = a.TransactionTypeName,
                        Remarks = a.Remarks
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<TransationTypeModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.TransactionTypes.Select(a => new TransationTypeModel()
                    {
                        TransactionTypeID = a.TransactionTypeID,
                        TransactionTypeName = a.TransactionTypeName,
                        Remarks = a.Remarks
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(TransationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new TransactionType()
                    {
                        TransactionTypeID = Model.TransactionTypeID,
                        TransactionTypeName = Model.TransactionTypeName,
                        Remarks = Model.Remarks
                    };
                    _context.TransactionTypes.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(TransationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.TransactionTypes.Where(a => a.TransactionTypeID == Model.TransactionTypeID).FirstOrDefault();
                    data.TransactionTypeName = Model.TransactionTypeName;
                    data.Remarks = Model.Remarks;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
