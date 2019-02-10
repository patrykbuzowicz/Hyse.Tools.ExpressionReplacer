using System.Linq;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
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
            if (!(other is MethodCallExpressionEqual equal))
                return false;

            if (!_node.Method.Equals(equal._node.Method))
                return false;

            return _node.Arguments.Count == equal._node.Arguments.Count;
        }
    }
}