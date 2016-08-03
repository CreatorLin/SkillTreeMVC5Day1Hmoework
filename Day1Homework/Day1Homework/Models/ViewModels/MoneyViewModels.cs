using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("類別")]
        public MoneyCategory Category { get; set; }
        [DisplayName("金額")]
        public decimal Money { get; set; }
        [DisplayName("日期")]
        public string Date { get; set; }
        [DisplayName("備註")]
        public string Description { get; set; }
    }
}