using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model;
using Services.Services;
using Services.IServices;
namespace Services.Services
{
    public class DonationService : IDonationService
    {
        public bool Delete(int DonationID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donations.Where(a => a.DonationID == DonationID).FirstOrDefault();
                    _context.Donations.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DonationModel GeDotionById(int DonationID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donations.Where(a => a.DonationID == DonationID).Select(a => new DonationModel()
                    {
                        DonationID = a.DonationID,
                        DonationTypeID = a.DonationTypeID,
                        DonorID = a.DonorID,
                        MemberID = a.MemberID,
                        Remarks = a.Remarks,
                        DonationFrom = a.DonationFrom,
                        DonationDescription = a.DonationDescription
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<DonationModel> ListAllDataM()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =( from d in _context.Donations
                                join m in _context.Members on d.MemberID equals m.MemberID
                               join dt in _context.DonationsTypes on d.DonationTypeID equals dt.DonationTypeID
                                select new DonationModel()
                                {
                                    DonationID = d.DonationID,
                                    DonationTypeID = dt.DonationTypeID,
                                    DonationTypeName = dt.DonationTypeName,
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    Remarks = d.Remarks,
                                    DonationFrom = d.DonationFrom,
                                    DonationDescription = d.DonationDescription
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<DonationModel> ListAllDataD()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =( from d in _context.Donations
                                join di in _context.Donors on d.DonorID equals di.DonorID
                                join dt in _context.DonationsTypes on d.DonationTypeID equals dt.DonationTypeID
                                select new DonationModel()
                                {
                                    DonationID = d.DonationID,
                                    DonationTypeID = dt.DonationTypeID,
                                    DonationTypeName = dt.DonationTypeName,
                                    DonorID = di.DonorID,
                                    DonorName = di.DonorName,
                                    Remarks = d.Remarks,
                                    DonationFrom = d.DonationFrom,
                                    DonationDescription = d.DonationDescription
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool SaveM(DonationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Donation()
                    {
                        DonationID = Model.DonationID,
                        DonationTypeID = Model.DonationTypeID,
                        MemberID = Model.MemberID,
                        DonorID= Model.DonorID,
                        Remarks = Model.Remarks,
                        DonationFrom = Model.DonationFrom,
                        DonationDescription = Model.DonationDescription
                    };
                    _context.Donations.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool SaveD(DonationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Donation()
                    {
                        DonationID = Model.DonationID,
                        DonationTypeID = Model.DonationTypeID,
                        DonorID = Model.DonorID,
                        MemberID = Model.MemberID,
                        Remarks = Model.Remarks,
                        DonationFrom = Model.DonationFrom,
                        DonationDescription = Model.DonationDescription
                        
                    };
                    _context.Donations.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool UpdateM(DonationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donations.Where(a => a.DonationID == Model.DonationID).FirstOrDefault();
                    data.DonationTypeID = Model.DonationTypeID;
                    data.MemberID = Model.MemberID;
                    data.Remarks = Model.Remarks;
                    data.DonationFrom = Model.DonationFrom;
                    data.DonationDescription = Model.DonationDescription;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        } 
        public bool UpdateD(DonationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donations.Where(a => a.DonationID == Model.DonationID).FirstOrDefault();
                    data.DonationTypeID = Model.DonationTypeID;
                    data.DonorID = Model.DonorID;
                    data.Remarks = Model.Remarks;
                    data.DonationFrom = Model.DonationFrom;
                    data.DonationDescription = Model.DonationDescription;
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
