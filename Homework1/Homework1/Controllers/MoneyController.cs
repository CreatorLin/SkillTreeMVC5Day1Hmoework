using Homework1.Managers;
using Homework1.Models;
using Homework1.Models.ViewModels;
using Homework1.Stores;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class MoneyController : Controller
    {
        private const string LIST_KEY = "MoneyList";
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyViewModel pageData)
        {
            if (ModelState.IsValid)
            {
                AddToDB(pageData);
                CleanCache();
            }

            return View("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate(MoneyViewModel pageData)
        {
            if (!ModelState.IsValid)
            {
                return new HttpNotFoundResult();
            }

            AddToDB(pageData);
            CleanCache();

            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var viewData = WebCache.Get(LIST_KEY);
            
            if (viewData == null)
            {
                viewData = manager.Lookup().Select(p => new MoneyViewModel()
                {
                    Category = (MoneyCategory)p.Categoryyy,
                    Money = p.Amounttt,
                    Date = p.Dateee
                }).ToList();
                WebCache.Set(LIST_KEY, viewData);
            }
            
            return PartialView(viewData);
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