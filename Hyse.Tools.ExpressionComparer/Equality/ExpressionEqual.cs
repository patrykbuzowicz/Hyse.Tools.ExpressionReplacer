using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
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