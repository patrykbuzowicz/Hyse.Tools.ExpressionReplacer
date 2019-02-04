using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Hyse.Tools.ExpressionReplacer
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

            if (memberExpression.Member is FieldInfo field)
                return field.GetValue(null) as LambdaExpression;
            if (memberExpression.Member is PropertyInfo property)
                return property.GetValue(null) as LambdaExpression;

            throw new InvalidOperationException($"Not supported member access: [{memberExpression.Member.GetType()}]");
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