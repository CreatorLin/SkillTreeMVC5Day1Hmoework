using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class MoneyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            return PartialView(new List<Models.ViewModels.MoneyViewModel>());
        }
    }
}