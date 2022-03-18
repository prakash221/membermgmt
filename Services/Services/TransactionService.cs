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
    public class TransactionService : ITransationService
    {
        public bool Delete(int TransactionID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Transactions.Where(a => a.TransactionID == TransactionID).FirstOrDefault();
                    _context.Transactions.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw; 
                }
            }
        }

        public TransactionModel GetTransactionById(int TransactionID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Transactions.Where(a => a.TransactionID == TransactionID).Select(a => new TransactionModel()
                    {
                        TransactionID = a.TransactionID,
                        TransactionTypeID = a.TransactionTypeID,
                        DonorID = a.DonorID,
                        MemberID = a.MemberID,
                        TransactionAmount = a.TransactionAmount,
                        TransactionDate = a.TransactionDate,
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

        public List<TransactionModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from t in _context.Transactions
                                join di in _context.Donors on t.DonorID equals di.DonorID
                                join m in _context.Members on t.MemberID equals m.MemberID
                                join tt in _context.TransactionTypes on t.TransactionTypeID equals tt.TransactionTypeID
                                select new TransactionModel()
                                {
                                    TransactionID = t.TransactionID,
                                    TransactionTypeID = tt.TransactionTypeID,
                                    TransactionTypeName = tt.TransactionTypeName,
                                    DonorID = di.DonorID,
                                    DonorName = di.DonorName,
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    TransactionAmount = t.TransactionAmount,
                                    TransactionDate = t.TransactionDate,
                                    Remarks = t.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<TransactionModel> ListAllDataDonation()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = (from t in _context.Transactions
                                join di in _context.Donors on t.DonorID equals di.DonorID
                                join tt in _context.TransactionTypes on t.TransactionTypeID equals tt.TransactionTypeID
                                where (tt.TransactionTypeID==1)
                                select new TransactionModel()
                                {
                                    TransactionID = t.TransactionID,
                                    TransactionTypeID = tt.TransactionTypeID,
                                    TransactionTypeName = tt.TransactionTypeName,
                                    DonorID = di.DonorID,
                                    DonorName = di.DonorName,
                                    TransactionAmount = t.TransactionAmount,
                                    TransactionDate = t.TransactionDate,
                                    Remarks = t.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<TransactionModel> ListAllDataFee()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = (from t in _context.Transactions
                                join m in _context.Members on t.MemberID equals m.MemberID
                                join tt in _context.TransactionTypes on t.TransactionTypeID equals tt.TransactionTypeID
                                where (tt.TransactionTypeID == 2)
                                select new TransactionModel()
                                {
                                    TransactionID = t.TransactionID,
                                    TransactionTypeID = tt.TransactionTypeID,
                                    TransactionTypeName = tt.TransactionTypeName,
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    TransactionAmount = t.TransactionAmount,
                                    TransactionDate = t.TransactionDate,
                                    Remarks = t.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<TransactionModel> ListAllDataFine()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = (from t in _context.Transactions
                                join m in _context.Members on t.MemberID equals m.MemberID
                                join tt in _context.TransactionTypes on t.TransactionTypeID equals tt.TransactionTypeID
                                where (tt.TransactionTypeID == 3)
                                select new TransactionModel()
                                {
                                    TransactionID = t.TransactionID,
                                    TransactionTypeID = tt.TransactionTypeID,
                                    TransactionTypeName = tt.TransactionTypeName,
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    TransactionAmount = t.TransactionAmount,
                                    TransactionDate = t.TransactionDate,
                                    Remarks = t.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(TransactionModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Transaction()
                    {
                        TransactionID = Model.TransactionID,
                        TransactionTypeID = Model.TransactionTypeID,
                        DonorID = Model.DonorID,
                        MemberID = Model.MemberID,
                        TransactionAmount = Model.TransactionAmount,
                        TransactionDate = Model.TransactionDate,
                        Remarks = Model.Remarks
                    };
                    _context.Transactions.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(TransactionModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Transactions.Where(a => a.TransactionID == Model.TransactionID).FirstOrDefault();
                    data.TransactionTypeID = Model.TransactionTypeID;
                    data.DonorID = Model.DonorID;
                    data.MemberID = Model.MemberID;
                    data.TransactionDate = Model.TransactionDate;
                    data.TransactionAmount = Model.TransactionAmount;
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
