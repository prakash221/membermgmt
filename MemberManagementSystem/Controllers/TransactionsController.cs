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
    public class TransactionsController : Controller
    {
        ITransationService transationService;
        ITransationTypeService TransationTypeService;
        IDonorService DonorService;
        IMemberService MemberService;
        IFineService  FineService;
        IMembershipFeeService MembershipFeeService;
        public TransactionsController()
        {
            transationService = new TransactionService();
            TransationTypeService = new TransactionTypeService();
            DonorService = new DonorService();
            MemberService = new MemberService();
            FineService = new FineService();
            MembershipFeeService = new MembershipFeeService();
        }
        // GET: Transaction
        public ActionResult Index()
        {
            var data = transationService.ListAllDataDonation();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult DonationEntry()
        {
            var data = TransationTypeService.GetTransactionTypeById(1);
            ViewBag.TTID = data.TransactionTypeID.ToString();
            ViewBag.TTName = data.TransactionTypeName.ToString();
            
            var data2 = DonorService.ListAllData();
            List<SelectListItem> donorlist = new List<SelectListItem>();
            foreach (DonorModel item in data2)
            {
                donorlist.Add(new SelectListItem
                {
                    Text = item.DonorName,
                    Value = item.DonorID.ToString()
                });
            }
            ViewBag.donors = donorlist;
            return View("DonationEntry");
        }
        [HttpGet]
        public ActionResult PayMembershipFee()
        {
            var data = TransationTypeService.GetTransactionTypeById(2);
            ViewBag.TTID = data.TransactionTypeID.ToString();
            ViewBag.TTName = data.TransactionTypeName.ToString();
            
            var data2 = MemberService.ListAllData();
            List<SelectListItem> memberlist = new List<SelectListItem>();
            foreach (MemberModel item in data2)
            {
                memberlist.Add(new SelectListItem
                {
                    Text = item.FirstName+" "+item.LastName + "-" + item.DesignationName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.members = memberlist;
            return View("PayMembershipFee");
        }
        [HttpGet]
        public ActionResult PayFine()
        {
            var data = TransationTypeService.GetTransactionTypeById(3);
            ViewBag.TTID = data.TransactionTypeID.ToString();
            ViewBag.TTName = data.TransactionTypeName.ToString();
            
            var data2 = MemberService.ListAllData();
            List<SelectListItem> memberlist = new List<SelectListItem>();
            foreach (MemberModel item in data2)
            {
                memberlist.Add(new SelectListItem
                {
                    Text = item.FirstName+" "+item.LastName + "-" + item.DesignationName,
                    Value = item.MemberID.ToString()
                });
            }
            ViewBag.members = memberlist;
            return View("PayFine");
        }
        
        [ChildActionOnly]
        public ActionResult RenderMFee()
        {
            var data = MembershipFeeService.ListAllData();
            return PartialView("FeeList",data);
        }
        [ChildActionOnly]
        public ActionResult RenderMFine()
        {
            var data = FineService.ListAllData();
            return PartialView("FineList",data);
        }
        
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = transationService.GetTransactionById(Id);
            return View("Edit", data);

        }

        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(TransactionModel Model)
        {
            transationService.Update(Model);
            var data = transationService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Create(TransactionModel Model)
        {
            transationService.Save(Model);
            var data = transationService.ListAllData();
            return View("Index", data);
        }
        public ActionResult PayMembershipFee(TransactionModel Model)
        {
            transationService.Save(Model);
            var data = transationService.ListAllDataFee();
            return View("Index", data);
        }
        public ActionResult PayFine(TransactionModel Model)
        {
            transationService.Save(Model);
            var data = transationService.ListAllDataFine();
            return View("Index", data);
        }
        public ActionResult DonationEntry(TransactionModel Model)
        {
            transationService.Save(Model);
            var data = transationService.ListAllDataDonation();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            transationService.Delete(Id);
            var data = transationService.ListAllData();
            return View("Index", data);
        }

    }
}