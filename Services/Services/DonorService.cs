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
    public class DonorService : IDonorService
    {
        public bool Delete(int DonorID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donors.Where(a => a.DonorID == DonorID).FirstOrDefault();
                    _context.Donors.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DonorModel GetDonorById(int DonorID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donors.Where(a => a.DonorID == DonorID).Select(a => new DonorModel()
                    {
                        DonorID = a.DonorID,
                        DonorName = a.DonorName,
                        ContactNumber = a.ContactNumber,
                        EmailAddress = a.EmailAddress,
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

        public List<DonorModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donors.Select(a => new DonorModel()
                    {
                        DonorID = a.DonorID,
                        DonorName = a.DonorName,
                        ContactNumber = a.ContactNumber,
                        EmailAddress = a.EmailAddress,
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

        public bool Save(DonorModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Donor()
                    {
                        DonorID = Model.DonorID,
                        DonorName = Model.DonorName,
                        ContactNumber = Model.ContactNumber,
                        EmailAddress = Model.EmailAddress,
                        Remarks = Model.Remarks
                    };
                    _context.Donors.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(DonorModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Donors.Where(a => a.DonorID == Model.DonorID).FirstOrDefault();
                    data.DonorName = Model.DonorName;
                    data.ContactNumber = Model.ContactNumber;
                    data.EmailAddress = Model.EmailAddress;
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
