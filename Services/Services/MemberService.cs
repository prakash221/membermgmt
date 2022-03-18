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
    public class MemberService : IMemberService
    {
        public bool Delete(int MemberD)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Members.Where(a => a.MemberID == MemberD).FirstOrDefault();
                    _context.Members.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public MemberModel GetMemberById(int MemberID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Members.Where(a => a.MemberID == MemberID).Select(a => new MemberModel()
                    {
                        MemberID = a.MemberID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Address = a.Address,
                        MobileNo = a.MobileNo,
                        Remarks = a.Remarks,
                        DesignationId = a.DesignationId,
                        OccupationID = a.OccupationID,
                        BranchID = a.BranchID
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<MemberModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from m in _context.Members
                               join d in _context.Designations on m.DesignationId equals d.DesignationID
                               join o in _context.Occupations on m.OccupationID equals o.OccupationID
                               join b in _context.Branches on m.BranchID equals b.BranchID
                               select new MemberModel()
                                {
                                    MemberID = m.MemberID,
                                    FirstName = m.FirstName,
                                    LastName = m.LastName,
                                    Address = m.Address,
                                    MobileNo = m.MobileNo,
                                    Remarks = m.Remarks,
                                    DesignationId = d.DesignationID,
                                    DesignationName = d.DesignationName,
                                    OccupationID = o.OccupationID,
                                    OccuptionName = o.OccupationName,
                                    BranchID = b.BranchID,
                                    BranchName = b.BranchName
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(MemberModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Member()
                    {
                        MemberID = Model.MemberID,
                        FirstName = Model.FirstName,
                        LastName = Model.LastName,
                        Address = Model.Address,
                        MobileNo = Model.MobileNo,
                        Remarks = Model.Remarks,
                        DesignationId = Model.DesignationId,
                        OccupationID = Model.OccupationID,
                        BranchID = Model.BranchID
                    };
                    _context.Members.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(MemberModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Members.Where(a => a.MemberID == Model.MemberID).FirstOrDefault();
                    data.FirstName = Model.FirstName;
                    data.LastName = Model.LastName;
                    data.Address = Model.Address;
                    data.MobileNo = Model.MobileNo;
                    data.Remarks = Model.Remarks;
                    data.OccupationID = Model.OccupationID;
                    data.BranchID = Model.BranchID;
                    data.DesignationId = Model.DesignationId;
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
