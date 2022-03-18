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
    public class DesignationTypeService : IDesignationTypeService
    {
        public bool Delete(int DesignationTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DesignationTypes.Where(a => a.DesignationTypeID == DesignationTypeID).FirstOrDefault();
                    _context.DesignationTypes.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DesignationTypeModel GetDesignationTypeById(int DesignationTypeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DesignationTypes.Where(a => a.DesignationTypeID == DesignationTypeID).Select(a => new DesignationTypeModel()
                    {
                        DesignationTypeID = a.DesignationTypeID,
                        DesinationTypeName = a.DesinationTypeName,
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

        public List<DesignationTypeModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DesignationTypes.Select(a => new DesignationTypeModel()
                    {
                        DesignationTypeID = a.DesignationTypeID,
                        DesinationTypeName = a.DesinationTypeName,
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

        public bool Save(DesignationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new DesignationType()
                    {
                        DesignationTypeID = Model.DesignationTypeID,
                        DesinationTypeName = Model.DesinationTypeName,
                        Remarks = Model.Remarks
                    };
                    _context.DesignationTypes.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(DesignationTypeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.DesignationTypes.Where(a => a.DesignationTypeID == Model.DesignationTypeID).FirstOrDefault();
                    data.DesinationTypeName = Model.DesinationTypeName;
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
