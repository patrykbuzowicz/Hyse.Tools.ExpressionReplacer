using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Replacing
{
    public class VariousWaysOfPassingExpression : TestsDataBase<TestCase>
    {
        private readonly Expression<Func<string, string>> _instanceField = x => x.Substring(x.Length - 2);
        private static readonly Expression<Func<string, string>> StaticField = x => x.Substring(x.Length - 2);

        private Expression<Func<string, string>> InstanceProp { get; } = x => x.Substring(x.Length - 2);

        private static Expression<Func<string, string>> StaticProp { get; } = x => x.Substring(x.Length - 2);

        protected override IEnumerable<TestCase> GetCases()
        {
            Expression<Func<string, string>> variable = x => x.Substring(x.Length - 2);

            yield return new TestCase
            {
                Reason = "Given simple expression as variable then it should apply the expression",
                Expression = x => Apply.This(x.Surname, variable),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given simple expression as instance field then it should apply the expression",
                Expression = x => Apply.This(x.Surname, _instanceField),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given simple expression as static field then it should apply the expression",
                Expression = x => Apply.This(x.Surname, StaticField),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given simple expression as instance prop then it should apply the expression",
                Expression = x => Apply.This(x.Surname, InstanceProp),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given simple expression as static prop then it should apply the expression",
                Expression = x => Apply.This(x.Surname, StaticProp),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };
        }
    }
}