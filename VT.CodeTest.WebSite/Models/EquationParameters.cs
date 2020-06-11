using System;
using System.Linq;
using System.Linq.Expressions;
using VT.CodeTest.WebSite.Equation;

namespace VT.CodeTest.WebSite.Models
{
    public class EquationParameters: IBinaryOperation
    {
        public Decimal Number1 { get; set; }
        public Decimal Number2 { get; set; }
        public ExpressionType Operator { get; set; }

        public Expression RightHandSide => Expression.Constant(Number2);

        public Expression LeftHandSide => Expression.Constant(Number1);

        public ExpressionType BinaryOperator =>  SupportedOperators.GetSupportedOperators().Values.Contains(Operator) ? Operator : throw new System.NotSupportedException();
    }

}
