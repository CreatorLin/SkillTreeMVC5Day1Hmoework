using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class ValidateController : Controller
    {
        public JsonResult GreaterThanToday(DateTime date)
        {
            bool greaterThanToday = date > DateTime.Today;

            return Json(!greaterThanToday, JsonRequestBehavior.AllowGet);
        }
    }
}