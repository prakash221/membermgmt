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
    public class DonationFromDonorController : Controller
    {
        IDonationService donationService;
        IDonationTypeService donationTypeService;
        IDonorService donorService;
        IMemberService memberService;
        public DonationFromDonorController()
        {
            donationService = new DonationService();
            donationTypeService = new DonationTypeService();
            donorService = new DonorService();
            memberService = new MemberService();
        }
        // GET: DonationFromDonor
        public ActionResult Index()
        {
            var data = donationService.ListAllDataD();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = donationService.GeDotionById(Id);

            var data2 = donationTypeService.ListAllData();
            List<SelectListItem> donationTypeList = new List<SelectListItem>();
            foreach (DonationTypeModel item in data2)
            {
                donationTypeList.Add(new SelectListItem
                {
                    Text = item.DonationTypeName,
                    Value = item.DonationTypeID.ToString()
                });
            }
            ViewBag.donationTypes = donationTypeList;

            var data4 = donorService.ListAllData();
            List<SelectListItem> donorIndividualList = new List<SelectListItem>();
            foreach (DonorModel item in data4)
            {
                donorIndividualList.Add(new SelectListItem
                {
                    Text = item.DonorName,
                    Value = item.DonorID.ToString()
                });
            }
            ViewBag.donorIndividuals = donorIndividualList;

            
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var data2 = donationTypeService.ListAllData();
            List<SelectListItem> donationTypeList = new List<SelectListItem>();
            foreach (DonationTypeModel item in data2)
            {
                donationTypeList.Add(new SelectListItem
                {
                    Text = item.DonationTypeName,
                    Value = item.DonationTypeID.ToString()
                });
            }
            ViewBag.donationTypes = donationTypeList;

            var data4 = donorService.ListAllData();
            List<SelectListItem> donorIndividualList = new List<SelectListItem>();
            foreach (DonorModel item in data4)
            {
                donorIndividualList.Add(new SelectListItem
                {
                    Text = item.DonorName,
                    Value = item.DonorID.ToString()
                });
            }
            ViewBag.donorIndividuals = donorIndividualList;

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(DonationModel Model)
        {
            donationService.UpdateD(Model);
            var data = donationService.ListAllDataD();
            return View("Index", data);
        }
        public ActionResult Create(DonationModel Model)
        {
            donationService.SaveD(Model);
            var data = donationService.ListAllDataD();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            donationService.Delete(Id);
            var data = donationService.ListAllDataD();
            return View("Index", data);
        }
    }
}