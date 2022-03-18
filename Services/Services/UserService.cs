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
    public class UserService : IUserService
    {
        public UserModel CheckAuthorization(UserModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = (from u in _context.Users.Where(a => a.UserName == Model.UserName && a.Password == Model.Password)
                                select new UserModel()

                                {
                                    UserID = u.UserID,
                                    UserName = u.UserName,
                                    Password = u.Password,
                                    MemberID = u.MemberID,
                                    EmailAddress = u.EmailAddress,
                                    IsActive = u.IsActive,
                                    Remarks = u.Remarks
                                }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Delete(int UserID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Users.Where(a => a.UserID == UserID).FirstOrDefault();
                    _context.Users.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public UserModel GetUserById(int UserID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Users.Where(a => a.UserID == UserID).Select(a => new UserModel()
                    {
                        UserID = a.UserID,
                        UserName = a.UserName,
                        Password = a.Password,
                        MemberID = a.MemberID,
                        EmailAddress = a.EmailAddress,
                        IsActive = a.IsActive,
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

        public List<UserModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from u in _context.Users
                               join m in _context.Members on u.MemberID equals m.MemberID
                               select new UserModel()
                                {
                                    UserID = u.UserID,
                                    UserName = u.UserName,
                                    Password = u.Password,
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    EmailAddress = u.EmailAddress,
                                    IsActive = u.IsActive,
                                    Remarks = u.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(UserModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new User()
                    {
                        UserID = Model.UserID,
                        UserName = Model.UserName,
                        Password = Model.Password,
                        MemberID = Model.MemberID,
                        EmailAddress = Model.EmailAddress,
                        IsActive = Model.IsActive,
                        Remarks = Model.Remarks
                    };
                    _context.Users.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(UserModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Users.Where(a => a.UserID == Model.UserID).FirstOrDefault();
                    data.UserName = Model.UserName;
                    data.Password = Model.Password;
                    data.MemberID = Model.MemberID;
                    data.EmailAddress = Model.EmailAddress;
                    data.IsActive = Model.IsActive;
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
