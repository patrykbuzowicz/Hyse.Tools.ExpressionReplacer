using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal abstract class ExpressionEqual
    {
        protected ExpressionEqual(Expression expression)
        {
            Expression = expression;
        }

        public Expression Expression { get; }

        public abstract bool Equals(ExpressionEqual other);
    }
}