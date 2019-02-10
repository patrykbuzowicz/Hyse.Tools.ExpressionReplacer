using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class MethodCallExpressionEqual : ExpressionEqual
    {
        private readonly MethodCallExpression _node;

        public MethodCallExpressionEqual(MethodCallExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            return other is MethodCallExpressionEqual equal &&
                   // consider _node.Arguments
                   _node.Method.Equals(equal._node.Method);
        }
    }
}