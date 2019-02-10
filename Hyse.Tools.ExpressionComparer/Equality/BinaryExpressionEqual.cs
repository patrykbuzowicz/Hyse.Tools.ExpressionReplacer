using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
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
            if (!(other is BinaryExpressionEqual equal))
                return false;
            
            if (!_node.NodeType.Equals(equal._node.NodeType))
                return false;
            if (_node.Method is null ^ equal._node.Method is null)
                return false;
            if (_node.Method != null && !_node.Method.Equals(equal._node.Method))
                return false;

            return ExpressionComparer.Compare(_node.Left, equal._node.Left) &&
                   ExpressionComparer.Compare(_node.Right, equal._node.Right);
        }
    }
}