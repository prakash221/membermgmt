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
    public class FineService : IFineService
    {
        public bool Delete(int FineID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Fines.Where(a => a.FineID == FineID).FirstOrDefault();
                    _context.Fines.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public FineModel GetFineById(int FineID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Fines.Where(a => a.FineID == FineID).Select(a => new FineModel()
                    {
                        FineID = a.FineID,
                        DesignationID = a.DesignationID,
                        Amount = a.Amount,
                        OrganizationLevelID = a.OrganizationLevelID,
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

        public List<FineModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from f in _context.Fines
                               join d in _context.Designations on f.DesignationID equals d.DesignationID
                               join ol in _context.OrganizationLevels on f.OrganizationLevelID equals ol.OrganizationLevelID
                               select new FineModel()
                                {
                                    FineID = f.FineID,
                                    DesignationID = d.DesignationID,
                                    DesignationName = d.DesignationName,
                                    Amount = f.Amount,
                                    OrganizationLevelID = ol.OrganizationLevelID,
                                    OrganizationLevelName = ol.OrganizationLevelName,
                                    Remarks = f.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(FineModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Fine()
                    {
                        FineID = Model.FineID,
                        DesignationID = Model.DesignationID,
                        Amount = Model.Amount,
                        OrganizationLevelID = Model.OrganizationLevelID,
                        Remarks = Model.Remarks
                    };
                    _context.Fines.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(FineModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Fines.Where(a => a.FineID == Model.FineID).FirstOrDefault();
                    data.DesignationID = Model.DesignationID;
                    data.Amount = Model.Amount;
                    data.OrganizationLevelID = Model.OrganizationLevelID;
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
