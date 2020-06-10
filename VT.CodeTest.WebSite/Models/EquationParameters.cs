using System;
using System.Linq.Expressions;

namespace VT.CodeTest.WebSite.Models
{
    public class EquationParameters
    {
        public Decimal Number1 { get; set; }
        public Decimal Number2 { get; set; }
        public ExpressionType Operator { get; set; }
    }
}
