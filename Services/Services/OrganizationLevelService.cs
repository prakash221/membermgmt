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
    public class OrganizationLevelService : IOrganizationLevelService
    {
        public bool Delete(int OrganizationLevelID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationLevels.Where(a => a.OrganizationLevelID == OrganizationLevelID).FirstOrDefault();
                    _context.OrganizationLevels.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public OrganizationLevelModel GetOrganizationLevelById(int OrganizationLevelID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationLevels.Where(a => a.OrganizationLevelID == OrganizationLevelID).Select(a => new OrganizationLevelModel()
                    {
                        OrganizationLevelID = a.OrganizationLevelID,
                        OrganizationLevelName = a.OrganizationLevelName,
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

        public List<OrganizationLevelModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationLevels.Select(a => new OrganizationLevelModel()
                    {
                        OrganizationLevelID = a.OrganizationLevelID,
                        OrganizationLevelName = a.OrganizationLevelName,
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

        public bool Save(OrganizationLevelModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new OrganizationLevel()
                    {
                        OrganizationLevelID = Model.OrganizationLevelID,
                        OrganizationLevelName = Model.OrganizationLevelName,
                        Remarks = Model.Remarks
                    };
                    _context.OrganizationLevels.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(OrganizationLevelModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationLevels.Where(a => a.OrganizationLevelID == Model.OrganizationLevelID).FirstOrDefault();
                    data.OrganizationLevelName = Model.OrganizationLevelName;
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
