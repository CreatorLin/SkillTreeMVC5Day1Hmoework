using Homework1.Controllers;
using Homework1.Models;
using Homework1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Areas.Power.Controllers
{
    [Authorize]
    public class AccountBookController : BaseController
    {
        // GET: Power/AccountBook
        public ActionResult Edit(Guid id)
        {
            var dbData = AccountBookManager.FindById(id);
            var viewModel = new MoneyViewModel()
            {
                Id = dbData.Id,
                Category = (MoneyCategory)dbData.Categoryyy,
                Description = dbData.Remarkkk,
                Money = dbData.Amounttt,
                Date = dbData.Dateee                
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoneyViewModel pageData)
        {
            if (!ModelState.IsValid)
            {
                return View(pageData);
            }

            AccountBookManager.SetAmounttt(pageData.Id, (int)pageData.Money);
            AccountBookManager.SetCategoryyyt(pageData.Id, (int)pageData.Category);
            AccountBookManager.SetDateee(pageData.Id, pageData.Date);
            AccountBookManager.SetRemarkkk(pageData.Id, pageData.Description);

            dbContext.SaveChanges();

            return Redirect("~/");
        }
    }
}