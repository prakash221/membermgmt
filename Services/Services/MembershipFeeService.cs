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
    public class MembershipFeeService : IMembershipFeeService
    {
        public bool Delete(int MembershipFeeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.MembershipFees.Where(a => a.MemberShipFeeID == MembershipFeeID).FirstOrDefault();
                    _context.MembershipFees.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public MembershipFeeModel GetMembershipFeeById(int MembershipFeeID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.MembershipFees.Where(a => a.MemberShipFeeID == MembershipFeeID).Select(a => new MembershipFeeModel()
                    {
                        MemberShipFeeID = a.MemberShipFeeID,
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

        public List<MembershipFeeModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from m in _context.MembershipFees
                               join d in _context.Designations on m.DesignationID equals d.DesignationID
                               join ol in _context.OrganizationLevels on m.OrganizationLevelID equals ol.OrganizationLevelID
                               select new MembershipFeeModel()
                                {
                                    MemberShipFeeID = m.MemberShipFeeID,
                                    DesignationID = d.DesignationID,
                                    DesignationName = d.DesignationName,
                                    Amount = m.Amount,
                                    OrganizationLevelID = ol.OrganizationLevelID,
                                    OrganizationLevelName = ol.OrganizationLevelName,
                                    Remarks = m.Remarks
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(MembershipFeeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new MembershipFee()
                    {
                        MemberShipFeeID = Model.MemberShipFeeID,
                        DesignationID = Model.DesignationID,
                        Amount = Model.Amount,
                        OrganizationLevelID = Model.OrganizationLevelID,
                        Remarks = Model.Remarks
                    };
                    _context.MembershipFees.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(MembershipFeeModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.MembershipFees.Where(a => a.MemberShipFeeID == Model.MemberShipFeeID).FirstOrDefault();
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
