using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
{
    internal class NewExpressionEqual : ExpressionEqual
    {
        private readonly NewExpression _node;

        public NewExpressionEqual(NewExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            return other is NewExpressionEqual equal &&
                   _node.Constructor.Equals(equal._node.Constructor);
        }
    }
}