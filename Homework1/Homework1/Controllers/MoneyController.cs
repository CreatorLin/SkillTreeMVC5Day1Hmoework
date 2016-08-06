using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class MoneyController : Controller
    {
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
            return PartialView(SampleData.MoneySampleData.Get());
        }
    }
}