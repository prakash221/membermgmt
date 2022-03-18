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
    public class DonationTypeService : IDonationTypeService
    {
        public bool Delete(int DonationTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DonationsTypes.Where(a => a.DonationTypeID == DonationTypeID).FirstOrDefault();
                    _context.DonationsTypes.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DonationTypeModel GetDonationTypeById(int DonationTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DonationsTypes.Where(a => a.DonationTypeID == DonationTypeID).Select(a => new DonationTypeModel()
                    {
                        DonationTypeID = a.DonationTypeID,
                        DonationTypeName = a.DonationTypeName,
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

        public List<DonationTypeModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DonationsTypes.Select(a => new DonationTypeModel()
                    {
                        DonationTypeID = a.DonationTypeID,
                        DonationTypeName = a.DonationTypeName,
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

        public bool Save(DonationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new DonationsType()
                    {
                        DonationTypeID = Model.DonationTypeID,
                        DonationTypeName = Model.DonationTypeName,
                        Remarks = Model.Remarks
                    };
                    _context.DonationsTypes.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(DonationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DonationsTypes.Where(a => a.DonationTypeID == Model.DonationTypeID).FirstOrDefault();
                    data.DonationTypeID = Model.DonationTypeID;
                    data.DonationTypeName = Model.DonationTypeName;
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
