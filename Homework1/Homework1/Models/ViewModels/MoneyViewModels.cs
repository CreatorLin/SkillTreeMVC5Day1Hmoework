using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        [HiddenInput]
        public Guid Id { get; set; }

        [DisplayName("類別")]
        [EnumDataType(typeof(MoneyCategory))]
        public MoneyCategory Category { get; set; }

        [DataType("Money")]
        [DisplayName("金額")]
        [Range(1, Int32.MaxValue)]
        public decimal Money { get; set; }

        [EndDate]
        [DisplayName("日期")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("備註")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string Description { get; set; }
    }
}