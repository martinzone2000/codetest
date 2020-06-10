using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VT.CodeTest.WebSite.Equation
{
    public static class SupportedOperators
    {
        public static Dictionary<string, ExpressionType> GetSupportedOperators()
        {
            var operators = new Dictionary<string, ExpressionType>();
            operators.Add("+", ExpressionType.Add);
            operators.Add("-", ExpressionType.Subtract);
            operators.Add("*", ExpressionType.Multiply);
            operators.Add("/", ExpressionType.Divide);
            return operators;
        }

        public static List<SelectListItem> GetSupportedOperatorsAsListItems()
        {
            var items = new List<SelectListItem>();
            foreach(var item in GetSupportedOperators())
            {
                items.Add(new SelectListItem(item.Key, ((int)item.Value).ToString()));
            }
            return items;
        }
    }
}
