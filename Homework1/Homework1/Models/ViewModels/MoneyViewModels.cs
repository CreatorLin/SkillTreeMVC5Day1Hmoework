using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Homework1.Models.ViewModels
{
    public enum MoneyCategory
    {
        [Display(Name ="收入")]
        Income,
        [Display(Name = "支出")]
        Expenses
    }

    public class MoneyViewModel
    {
        [DisplayName("類別")]
        public MoneyCategory Category { get; set; }
        [DataType("Money")]
        [DisplayName("金額")]
        [Range(1, Int32.MaxValue)]
        public decimal Money { get; set; }
        [DisplayName("日期")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DisplayName("備註")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}