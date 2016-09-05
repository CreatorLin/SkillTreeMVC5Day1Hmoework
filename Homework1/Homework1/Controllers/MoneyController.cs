using Homework1.Managers;
using Homework1.Models;
using Homework1.Models.ViewModels;
using Homework1.Stores;
using PagedList;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class MoneyController : BaseController
    {
        private const string LIST_KEY = "MoneyList";
        private AccountBookManager manager;

        public MoneyController()
        {
            var store = new Store<AccountBook>(dbContext);
            manager = new AccountBookManager(store);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyViewModel pageData)
        {
            if (ModelState.IsValid)
            {
                CommonCreate(pageData);
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate(MoneyViewModel pageData)
        {
            if (!ModelState.IsValid)
            {
                return new HttpNotFoundResult();
            }

            CommonCreate(pageData);

            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult List(int? year, int? month, int? page)
        {
            var dbData = WebCache.Get(LIST_KEY);
            
            if (dbData == null)
            {
                dbData = manager.Lookup().Select(p => new MoneyViewModel()
                {
                    Id = p.Id,
                    Category = (MoneyCategory)p.Categoryyy,
                    Money = p.Amounttt,
                    Date = p.Dateee
                }).ToList().OrderBy(p => p.Date);
                WebCache.Set(LIST_KEY, dbData, 1);
            }

            var pageNumber = page ?? 1;
            var pageData = (dbData as IEnumerable<MoneyViewModel>);

            if(year.HasValue && month.HasValue)
            {
                pageData = pageData.Where(p => p.Date.Year == year && p.Date.Month == month);
            }

            return PartialView(pageData.ToPagedList(pageNumber, 10));
        }

        private void CommonCreate(MoneyViewModel data)
        {
            AddToDB(data);
            dbContext.SaveChanges();
            CleanCache();
        }

        private void AddToDB(MoneyViewModel pageData)
        {
            var model = new AccountBook()
            {
                Dateee = pageData.Date,
                Amounttt = (int)pageData.Money,
                Categoryyy = (int)pageData.Category,
                Remarkkk = pageData.Description
            };

            manager.Add(model);
        }

        private void CleanCache()
        {
            WebCache.Remove(LIST_KEY);
        }
    }
}