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
    public class BranchService : IBranchService
    {
        public bool Delete(int BranchID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Branches.Where(a => a.BranchID == BranchID).FirstOrDefault();
                    _context.Branches.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public BranchModel GetBranchById(int BranchID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Branches.Where(a => a.BranchID == BranchID).Select(a => new BranchModel()
                    {
                        BranchID = a.BranchID,
                        BranchName = a.BranchName,
                        BranchCity = a.BranchCity,
                        BranchCountry = a.BranchCountry,
                        BranchEmail = a.BranchEmail,
                        BranchDistrict = a.BranchDistrict,
                        BranchProvinceState = a.BranchProvinceState,
                        BranchPhoneNumber = a.BranchPhoneNumber,
                        OrganizationLevelID = a.OrganizationLevelID
                    }).FirstOrDefault();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<BranchModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data =(from b in _context.Branches
                               join ol in _context.OrganizationLevels on b.OrganizationLevelID equals ol.OrganizationLevelID
                               select new BranchModel()
                                {
                                    BranchID = b.BranchID,
                                    BranchName = b.BranchName,
                                    BranchCity = b.BranchCity,
                                    BranchCountry = b.BranchCountry,
                                    BranchEmail = b.BranchEmail,
                                    BranchDistrict = b.BranchDistrict,
                                    BranchProvinceState = b.BranchProvinceState,
                                    BranchPhoneNumber = b.BranchPhoneNumber,
                                    OrganizationLevelID = ol.OrganizationLevelID,
                                    OrganizationLevelName = ol.OrganizationLevelName
                                }).ToList();
                    return data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Save(BranchModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new Branch()
                    {
                        BranchID = Model.BranchID,
                        BranchName = Model.BranchName,
                        BranchCity = Model.BranchCity,
                        BranchCountry = Model.BranchCountry,
                        BranchEmail = Model.BranchEmail,
                        BranchDistrict = Model.BranchDistrict,
                        BranchProvinceState = Model.BranchProvinceState,
                        BranchPhoneNumber = Model.BranchPhoneNumber,
                        OrganizationLevelID=Model.OrganizationLevelID
                    };
                    _context.Branches.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(BranchModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.Branches.Where(a => a.BranchID == Model.BranchID).FirstOrDefault();
                    data.BranchName = Model.BranchName;
                    data.BranchCity = Model.BranchCity;
                    data.BranchDistrict = Model.BranchDistrict;
                    data.BranchProvinceState = Model.BranchProvinceState;
                    data.BranchCountry = Model.BranchCountry;
                    data.BranchPhoneNumber = Model.BranchPhoneNumber;
                    data.BranchEmail = Model.BranchEmail;
                    data.OrganizationLevelID = Model.OrganizationLevelID;
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
