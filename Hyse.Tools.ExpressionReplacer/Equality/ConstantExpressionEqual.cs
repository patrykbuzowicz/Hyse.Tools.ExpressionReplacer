using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class ConstantExpressionEqual : ExpressionEqual
    {
        private readonly ConstantExpression _node;

        public ConstantExpressionEqual(ConstantExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            return other is ConstantExpressionEqual equal && Equals(_node.Value, equal._node.Value);
        }
    }
}