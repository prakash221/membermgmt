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
    public class AchievementService : IAchievementService
    {
        public bool Delete(int AchievementID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Achievements.Where(a => a.AchievementID == AchievementID).FirstOrDefault();
                    _context.Achievements.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public AchievementModel GetAchievementById(int AchievementID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Achievements.Where(a => a.AchievementID == AchievementID).Select(a => new AchievementModel()
                    {
                        AchievementID = a.AchievementID,
                        AwardId = a.AwardId,
                        MemberID = a.MemberID,
                        AchieveDate= a.AchieveDate
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<AchievementModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from a in _context.Achievements
                               join aw in _context.Awards on a.AwardId equals aw.AwardID
                               join m in _context.Members on a.MemberID equals m.MemberID
                               select new AchievementModel()
                                {
                                    AchievementID = a.AchievementID,
                                    AwardId = aw.AwardID,
                                    AwardName = aw.AwardName,
                                    MemberID = m.MemberID,
                                    FirstName =m.FirstName,
                                   LastName = m.LastName,
                                   AchieveDate = a.AchieveDate
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(AchievementModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Achievement()
                    {
                        AchievementID = Model.AchievementID,
                        AwardId = Model.AwardId,
                        MemberID = Model.MemberID,
                        AchieveDate = Model.AchieveDate
                    };
                    _context.Achievements.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(AchievementModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Achievements.Where(a => a.AchievementID == Model.AchievementID).FirstOrDefault();
                    data.AwardId = Model.AwardId;
                    data.MemberID = Model.MemberID;
                    data.AchieveDate = Model.AchieveDate;
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
