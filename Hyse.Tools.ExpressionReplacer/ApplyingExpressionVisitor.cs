using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer
{
    internal class ApplyingExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _replacement;

        public ApplyingExpressionVisitor(Expression replacement)
        {
            _replacement = replacement;
        }

        protected override Expression VisitParameter(ParameterExpression node) => _replacement;
    }
}
