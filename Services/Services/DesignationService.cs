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
    public class DesignationService : IDesignationService
    {
        public bool Delete(int DesignationID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Designations.Where(a => a.DesignationID == DesignationID).FirstOrDefault();
                    _context.Designations.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DesignationModel GetDesignationById(int DesignationID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Designations.Where(a => a.DesignationID == DesignationID).Select(a => new DesignationModel()
                    {
                        DesignationID = a.DesignationID,
                        DesignationName = a.DesignationName,
                        DesignationTypeID = a.DesignationTypeID,
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

        public List<DesignationModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from d in _context.Designations
                               join dt in _context.DesignationTypes on d.DesignationTypeID equals dt.DesignationTypeID
                               select new DesignationModel()
                                {
                                    DesignationID = d.DesignationID,
                                    DesignationName = d.DesignationName,
                                    DesignationTypeID = dt.DesignationTypeID,
                                    DesignationTypeName = dt.DesinationTypeName,
                                    Remarks = d.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(DesignationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Designation()
                    {
                        DesignationID = Model.DesignationID,
                        DesignationName = Model.DesignationName,
                        DesignationTypeID = Model.DesignationTypeID,
                        Remarks = Model.Remarks
                    };
                    _context.Designations.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(DesignationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Designations.Where(a => a.DesignationID == Model.DesignationID).FirstOrDefault();
                    data.DesignationName = Model.DesignationName;
                    data.DesignationTypeID = Model.DesignationTypeID;
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
