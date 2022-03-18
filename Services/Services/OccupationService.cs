using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model;
using Services.IServices;
using Services.Services;
namespace Services.Services
{
    public class OccupationService : IOccuptionService
    {
        public bool Delete(int OccuptionID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Occupations.Where(a => a.OccupationID == OccuptionID).FirstOrDefault();
                    _context.Occupations.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public OccupationModel GetOccuptionById(int OccuptionID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Occupations.Where(a => a.OccupationID == OccuptionID).Select(a => new OccupationModel()
                    {
                        OccupationID = a.OccupationID,
                        OccupationName = a.OccupationName,
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

        public List<OccupationModel> ListAllData()
        {
            using(var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Occupations.Select(a => new OccupationModel()
                    {
                        OccupationID = a.OccupationID,
                        OccupationName = a.OccupationName,
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

        public bool Save(OccupationModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Occupation()
                    {
                        OccupationID = Model.OccupationID,
                        OccupationName = Model.OccupationName,
                        Remarks = Model.Remarks
                    };
                    _context.Occupations.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(OccupationModel Model)
        {
           using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Occupations.Where(a => a.OccupationID == Model.OccupationID).FirstOrDefault();
                    data.OccupationName = Model.OccupationName;
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
