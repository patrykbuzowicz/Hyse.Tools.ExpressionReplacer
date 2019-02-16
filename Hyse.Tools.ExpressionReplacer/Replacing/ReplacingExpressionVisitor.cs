using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Hyse.Tools.ExpressionReplacer.Replacing
{
    internal class ReplacingExpressionVisitor : ExpressionVisitor
    {
        private static readonly MethodInfo ApplyThisMethod = typeof(Apply).GetMethod(nameof(Apply.This));

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (!IsApplyThisMethod(node.Method))
                return base.VisitMethodCall(node);

            var argument = node.Arguments[0];
            var innerExpression = ExtractInnerExpression(node.Arguments[1]);
            var applied = ApplyExpression(innerExpression, argument);

            return applied;
        }

        private bool IsApplyThisMethod(MethodInfo method) => method.GetGenericMethodDefinition() == ApplyThisMethod;

        private LambdaExpression ExtractInnerExpression(Expression argument)
        {
            if (!(argument is MemberExpression memberExpression))
                throw new InvalidOperationException($"Not supported expression type: [{argument.GetType()}]");

            var accessorExpression = Expression.Lambda<Func<LambdaExpression>>(memberExpression);
            var compiledAccessor = accessorExpression.Compile();
            return compiledAccessor();
        }

        private Expression ApplyExpression(LambdaExpression innerExpression, Expression argument)
        {
            var body = innerExpression.Body;
            var applyingVisitor = new ApplyingExpressionVisitor(argument);

            var result = applyingVisitor.Visit(body);
            return result;
        }
    }
}