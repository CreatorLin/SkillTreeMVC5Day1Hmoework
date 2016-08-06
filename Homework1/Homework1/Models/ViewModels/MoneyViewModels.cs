using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework1.Models.ViewModels
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
        [DataType("Money")]
        public decimal Money { get; set; }
        [DisplayName("日期")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DisplayName("備註")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}