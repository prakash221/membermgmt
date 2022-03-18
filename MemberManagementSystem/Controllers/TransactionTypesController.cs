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
    public class TransactionTypesController : Controller
    {
        ITransationTypeService transationTypeService;
        public TransactionTypesController()
        {
            transationTypeService = new TransactionTypeService();
        }
        // GET: TransactionType
        public ActionResult Index()
        {
            var data = transationTypeService.ListAllData();
            return View("Index", data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = transationTypeService.GetTransactionTypeById(Id);
            return View("Edit", data);

        }
        [HttpGet]
        public ActionResult Save()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(TransationTypeModel Model)
        {
            transationTypeService.Update(Model);
            var data = transationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Save(TransationTypeModel Model)
        {
            transationTypeService.Save(Model);
            var data = transationTypeService.ListAllData();
            return View("Index", data);
        }
        public ActionResult Delete(int Id)
        {
            transationTypeService.Delete(Id);
            var data = transationTypeService.ListAllData();
            return View("Index", data);
        }
    }
}