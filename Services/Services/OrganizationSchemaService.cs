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
    public class OrganizationSchemaService : IOrganizationSchemaService
    {
        public bool Delete(int SchemaObjectID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationSchemas.Where(a => a.SchemaObjectID == SchemaObjectID).FirstOrDefault();
                    _context.OrganizationSchemas.Remove(data);
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public OrganizationSchemaModel GetOrganizationSchemaById(int SchemaObjectID)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationSchemas.Where(a => a.SchemaObjectID == SchemaObjectID).Select(a => new OrganizationSchemaModel()
                    {
                        SchemaObjectID = a.SchemaObjectID,
                        SchemaObjectName = a.SchemaObjectName,
                        SchemaObjectValue = a.SchemaObjectValue,
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

        public List<OrganizationSchemaModel> ListAllData()
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationSchemas.Select(a => new OrganizationSchemaModel()
                    {
                        SchemaObjectID = a.SchemaObjectID,
                        SchemaObjectName = a.SchemaObjectName,
                        SchemaObjectValue = a.SchemaObjectValue,
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

        public bool Save(OrganizationSchemaModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = new OrganizationSchema()
                    {
                        SchemaObjectID = Model.SchemaObjectID,
                        SchemaObjectName = Model.SchemaObjectName,
                        SchemaObjectValue = Model.SchemaObjectValue,
                        Remarks = Model.Remarks
                    };
                    _context.OrganizationSchemas.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Update(OrganizationSchemaModel Model)
        {
            using (var _context = new MemberMSEntities())
            {
                try
                {
                    var data = _context.OrganizationSchemas.Where(a => a.SchemaObjectID == Model.SchemaObjectID).FirstOrDefault();
                    data.SchemaObjectName = Model.SchemaObjectName;
                    data.SchemaObjectValue = Model.SchemaObjectValue;
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
