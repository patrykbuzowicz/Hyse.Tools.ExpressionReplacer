using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
{
    internal class ParameterExpressionEqual : ExpressionEqual
    {
        private readonly ParameterExpression _node;

        public ParameterExpressionEqual(ParameterExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            return other is ParameterExpressionEqual equal &&
                   _node.Name.Equals(equal._node.Name) &&
                   _node.IsByRef == equal._node.IsByRef;
        }
    }
}