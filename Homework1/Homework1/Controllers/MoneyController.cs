using Homework1.Managers;
using Homework1.Models;
using Homework1.Models.ViewModels;
using Homework1.Stores;
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
            var store = new Store<AccountBook>(dbContext);

            manager = new AccountBookManager(store);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MoneyViewModel pageData)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var model = new AccountBook()
            {
                Dateee = pageData.Date,
                Amounttt = (int)pageData.Money,
                Categoryyy = (int)pageData.Category,
                Remarkkk = pageData.Description
            };

            manager.Add(model);

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