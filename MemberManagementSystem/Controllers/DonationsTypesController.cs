using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Services.Services;
using Services.IServices;
namespace MemberManagementSystem.Controllers
{
    public class DonationsTypesController : Controller
    {
        IDonationTypeService donationTypeService;
        public DonationsTypesController()
        {
            donationTypeService = new DonationTypeService();
        }
        // GET: DonationType
        public ActionResult Index()
        {
            var data = donationTypeService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = donationTypeService.GetDonationTypeById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DonationTypeModel Model)
        {
            donationTypeService.Update(Model);
            var data = donationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(DonationTypeModel Model)
        {
            donationTypeService.Save(Model);
            var data = donationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            donationTypeService.Delete(Id);
            var data = donationTypeService.ListAllData();
            return View("Index", data);
        }
    }
}