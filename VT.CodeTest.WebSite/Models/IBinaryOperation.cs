using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VT.CodeTest.WebSite.Models
{
    public interface IBinaryOperation
    {
        Expression RightHandSide { get; }
        Expression LeftHandSide { get; }
        ExpressionType BinaryOperator { get; }
    }
}
