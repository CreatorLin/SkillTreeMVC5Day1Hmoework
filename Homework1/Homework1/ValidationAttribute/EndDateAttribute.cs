using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace System.ComponentModel.DataAnnotations
{

    public sealed class EndDateAttribute : ValidationAttribute, IClientValidatable, IMetadataAware
    {
        private DateTime endDate;

        public EndDateAttribute(int addDays = 0)
        {
            endDate = DateTime.Now.AddDays(addDays);
        }
        public EndDateAttribute(int year, int month, int day)
        {
            endDate = new DateTime(year, month, day);
        }
        
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "Date";
            metadata.AdditionalValues["endDateYear"] = endDate.Year;
            metadata.AdditionalValues["endDateMonth"] = endDate.Month;
            metadata.AdditionalValues["endDateDay"] = endDate.Day;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var compareDate = value as DateTime?;
            
            if (compareDate.HasValue && compareDate.Value.Date > endDate)
            {
                ErrorMessage = $"{{0}} 不能超過日期 {endDate.ToShortDateString()}";
                return false;
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                ValidationType = "enddate",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            
            rule.ValidationParameters["date"] = endDate.ToShortDateString();
            yield return rule;
        }
    }
}

