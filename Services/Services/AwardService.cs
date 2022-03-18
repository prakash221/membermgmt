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
    public class AwardService : IAwardService
    {
        public bool Delete(int AwardID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Awards.Where(a => a.AwardID == AwardID).FirstOrDefault();
                    _context.Awards.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public AwardModel GetAwardById(int AwardID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Awards.Where(a => a.AwardID == AwardID).Select(a => new AwardModel()
                    {
                        AwardID = a.AwardID,
                        AwardName = a.AwardName,
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

        public List<AwardModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Awards.Select(a => new AwardModel()
                    {
                        AwardID = a.AwardID,
                        AwardName = a.AwardName,
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

        public bool Save(AwardModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Award()
                    {
                        AwardID = Model.AwardID,
                        AwardName = Model.AwardName,
                        Remarks = Model.Remarks
                    };
                    _context.Awards.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(AwardModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Awards.Where(a => a.AwardID == Model.AwardID).FirstOrDefault();
                    data.AwardName = Model.AwardName;
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
