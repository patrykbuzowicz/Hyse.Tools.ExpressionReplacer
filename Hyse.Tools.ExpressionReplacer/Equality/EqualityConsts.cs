using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class EqualityConsts
    {
        public static readonly Dictionary<Type, Type> ExpressionToComparer = new Dictionary<Type, Type>
        {
            {typeof(ConstantExpression), typeof(ConstantExpressionEqual)}
        };
    }
}
