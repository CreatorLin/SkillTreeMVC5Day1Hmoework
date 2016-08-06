using Homework1.Managers;
using Homework1.Models;
using Homework1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class MoneyController : Controller
    {
        private AccountBookManager manager;

        public MoneyController()
        {
            var dbContext = new MyEntity();

            manager = new AccountBookManager(dbContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var viewData = manager.Lookup().Select(p => new MoneyViewModel()
            {
                Category = (MoneyCategory)p.Categoryyy,
                Money = p.Amounttt,
                Date = p.Dateee
            }).ToList();
            
            return PartialView(viewData);
        }
    }
}