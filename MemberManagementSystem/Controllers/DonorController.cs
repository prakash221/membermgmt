using Model;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberManagementSystem.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        IDonorService DonorService;
        public DonorController()
        {
            DonorService = new DonorService();
        }
        // GET: DonorIndividual
        public ActionResult Index()
        {
            var data = DonorService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = DonorService.GetDonorById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DonorModel Model)
        {
            DonorService.Update(Model);
            var data = DonorService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(DonorModel Model)
        {
            DonorService.Save(Model);
            var data = DonorService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            DonorService.Delete(Id);
            var data = DonorService.ListAllData();
            return View("Index", data);
        }
    }
}