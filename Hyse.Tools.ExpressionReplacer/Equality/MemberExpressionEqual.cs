using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Equality
{
    internal class MemberExpressionEqual : ExpressionEqual
    {
        private readonly MemberExpression _node;

        public MemberExpressionEqual(MemberExpression node)
            : base(node)
        {
            _node = node;
        }

        public override bool Equals(ExpressionEqual other)
        {
            return other is MemberExpressionEqual equal && 
                   _node.Member.Equals(equal._node.Member);
        }
    }
}