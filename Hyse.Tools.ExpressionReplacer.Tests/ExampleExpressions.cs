using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    internal class ExampleExpressions
    {
        public static readonly Expression<Func<string, string>> TwoLastChars = x => x.Substring(x.Length - 2);

        public static readonly Expression<Func<ExampleModel, bool>> TwoStringFieldsAssertion =
            x => x.Name.Substring(0, 1) == x.Surname.Substring(x.Surname.Length - 1);

        public static readonly Expression<Func<ExampleModel, bool>> NameAssertion = x => x.Name.StartsWith("someone");
        public static readonly Expression<Func<ExampleModel, bool>> SurnameAssertion = x => x.Surname.StartsWith("something");
        public static readonly Expression<Func<ExampleModel, bool>> AgeAssertion = x => x.Age > 18;
    }
}
