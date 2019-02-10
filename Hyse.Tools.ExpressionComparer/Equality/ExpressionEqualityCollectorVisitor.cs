using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
{
    internal class ExpressionEqualityCollectorVisitor : ExpressionVisitor
    {
        //protected override CatchBlock VisitCatchBlock(CatchBlock node);

        //protected override ElementInit VisitElementInit(ElementInit node);

        //protected override LabelTarget VisitLabelTarget(LabelTarget node);

        //protected override MemberAssignment VisitMemberAssignment(MemberAssignment node);

        //protected override MemberBinding VisitMemberBinding(MemberBinding node);

        //protected override MemberListBinding VisitMemberListBinding(MemberListBinding node);

        //protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node);

        //protected override SwitchCase VisitSwitchCase(SwitchCase node);

        public readonly List<ExpressionEqual> ExpressionEquals = new List<ExpressionEqual>();

        private Expression Add(ExpressionEqual expressionEqual)
        {
            ExpressionEquals.Add(expressionEqual);
            return expressionEqual.Expression;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Add(new BinaryExpressionEqual(node));
            return base.VisitBinary(node);
        }

        //protected override Expression VisitBlock(BlockExpression node) => Add(new BlockExpressionEqual(node));

        //protected override Expression VisitConditional(ConditionalExpression node) => Add(new ConditionalExpressionEqual(node));

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Add(new ConstantExpressionEqual(node));
            return base.VisitConstant(node);
        }

        //protected override Expression VisitDebugInfo(DebugInfoExpression node);

        //protected override Expression VisitDefault(DefaultExpression node);

        //protected override Expression VisitDynamic(DynamicExpression node);

        //protected override Expression VisitExtension(Expression node);

        //protected override Expression VisitGoto(GotoExpression node);

        //protected override Expression VisitIndex(IndexExpression node);

        //protected override Expression VisitInvocation(InvocationExpression node);

        //protected override Expression VisitLabel(LabelExpression node);

        //protected override Expression VisitLambda<T>(Expression<T> node);

        //protected override Expression VisitListInit(ListInitExpression node);

        //protected override Expression VisitLoop(LoopExpression node);

        protected override Expression VisitMember(MemberExpression node)
        {
            Add(new MemberExpressionEqual(node));
            return base.VisitMember(node);
        }

        //protected override Expression VisitMemberInit(MemberInitExpression node);

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            Add(new MethodCallExpressionEqual(node));
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            Add(new NewExpressionEqual(node));
            return base.VisitNew(node);
        }

        //protected override Expression VisitNewArray(NewArrayExpression node);

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Add(new ParameterExpressionEqual(node));
            return base.VisitParameter(node);
        }

        //protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node);

        //protected override Expression VisitSwitch(SwitchExpression node);

        //protected override Expression VisitTry(TryExpression node);

        //protected override Expression VisitTypeBinary(TypeBinaryExpression node);

        //protected override Expression VisitUnary(UnaryExpression node);
    }
}
