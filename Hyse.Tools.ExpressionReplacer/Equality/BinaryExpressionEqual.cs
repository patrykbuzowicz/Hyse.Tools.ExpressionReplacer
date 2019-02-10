using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class BinaryExpressionEqual : ExpressionEqual
    {
        private readonly BinaryExpression _node;

        public BinaryExpressionEqual(BinaryExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            if (!(other is BinaryExpressionEqual equal)) return false;

            if (_node.Method is null && equal._node.Method is null)
                return _node.NodeType.Equals(equal._node.NodeType);
            if (_node.Method is null || equal._node.Method is null)
                return false;

            return _node.Method.Equals(equal._node.Method);
        }
    }
}