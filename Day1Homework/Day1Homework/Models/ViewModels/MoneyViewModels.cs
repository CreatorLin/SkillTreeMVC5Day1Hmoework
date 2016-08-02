using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.Models.ViewModels
{
    public enum MoneyCategory
    {
        收入 = 1,
        支出
    }

    public class MoneyViewModel
    {
        public MoneyCategory Category { get; set; }
        public decimal Money { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}