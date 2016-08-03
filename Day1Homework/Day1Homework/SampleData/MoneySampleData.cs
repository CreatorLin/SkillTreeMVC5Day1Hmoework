using Day1Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.SampleData
{
    public class MoneySampleData
    {
        static private IEnumerable<MoneyViewModel> Data = Enumerable.Range(1, 5)
                                                                    .Select(p => new MoneyViewModel()
                                                                    {
                                                                        Category = (MoneyCategory)(p % Enum.GetValues(typeof(MoneyCategory)).Length + 1),
                                                                        Date = DateTime.UtcNow.AddDays(-p),
                                                                        Money = new int[] { 1000, 1000000 }.ElementAt(p % 2) * p,
                                                                        Description = $"測試備註{p}"
                                                                    });          

        static public IEnumerable<MoneyViewModel> Get()
        {
            return Data;
        }
    }
}