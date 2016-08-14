using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace System.Web.Mvc
{
    public class RemoteDoublePlusAttribute : RemoteAttribute
    {
        private string action { get; set; }
        private string controller { get; set; }
        private string area { get; set; }



        public RemoteDoublePlusAttribute(string action, string controller, string area)
            : base(action, controller, area)
        {
            this.action = action;
            this.controller = controller;
            this.area = area;

            //修正 Remote 驗證遇到根 Area 的問題
            //http://demo.tc/Post/756
            this.RouteData["area"] = area;
        }

        //覆寫 IsValid 方法 實作後端驗證
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var additionalFields = this.AdditionalFields.Split(',');
            var propValues = new List<object>();
            propValues.Add(value);
            foreach (string additionalField in additionalFields)
            {
                var prop = validationContext.ObjectType.GetProperty(additionalField);
                if (prop != null)
                {
                    object propValue = prop.GetValue(validationContext.ObjectInstance, null);
                    propValues.Add(propValue);
                }
            }

            var controllerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(d => d.Name.ToLower() == (this.controller + "Controller").ToLower());
            if (controllerType != null)
            {
                var instance = Activator.CreateInstance(controllerType);

                var method = controllerType.GetMethod(this.action);

                if (method != null)
                {
                    ActionResult response = (ActionResult)method.Invoke(instance, propValues.ToArray());

                    if (response is JsonResult)
                    {
                        bool isAvailable = false;
                        JsonResult json = (JsonResult)response;
                        string jsonData = Convert.ToString(json.Data);

                        bool.TryParse(jsonData, out isAvailable);

                        if (!isAvailable)
                        {
                            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                        }
                    }
                }
            }
            return null;
        }
    }
}
