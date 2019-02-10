using System.Linq;
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
            if (!(other is MethodCallExpressionEqual equal))
                return false;

            if (!_node.Method.Equals(equal._node.Method))
                return false;

            if (_node.Arguments.Count != equal._node.Arguments.Count)
                return false;

            return _node.Arguments
                .Zip(equal._node.Arguments, (left, right) => new {left, right})
                .All(args => ExpressionComparer.Compare(args.left, args.right));
        }
    }
}