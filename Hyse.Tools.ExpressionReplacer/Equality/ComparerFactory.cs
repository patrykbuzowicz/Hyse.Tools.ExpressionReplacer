using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class ComparerFactory
    {
        public static ExpressionEqual Create(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var expressionType = expression.GetType();
            if (!EqualityConsts.ExpressionToComparer.TryGetValue(expressionType, out var comparerType))
                throw new ArgumentException($"Expression type not supported: [{expressionType.FullName}]");

            var comparerInstance = Activator.CreateInstance(comparerType, expression);
            return comparerInstance as ExpressionEqual;
        }
    }
}