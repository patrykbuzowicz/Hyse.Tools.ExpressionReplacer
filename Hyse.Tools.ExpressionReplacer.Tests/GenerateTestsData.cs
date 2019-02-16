using System.Collections.Generic;
using Hyse.Tools.ExpressionReplacer.Tests.Replacing;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    public class GenerateTestsData : TestsDataBase<TestCase>
    {
        protected override IEnumerable<TestCase> GetCases()
        {
            yield return new TestCase
            {
                Reason = "Given expression does not contain updates Then it should return expression unchanged",
                Expression = x => x.Name,
                Expected = x => x.Name
            };

            yield return new TestCase
            {
                Reason = "Given expression is updated with simple equality check Then it should return changed expression",
                Expression = x => x.Name == Apply.This(x.Surname, ExampleExpressions.TwoLastChars),
                Expected = x => x.Name == x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given expression is updated with complex expression Then it should return changed expression",
                Expression = x => x.Age > 30 && Apply.This(x, ExampleExpressions.TwoStringFieldsAssertion),
                Expected = x => x.Age > 30 &&
                                x.Name.Substring(0, 1) == x.Surname.Substring(x.Surname.Length - 1)
            };

            yield return new TestCase
            {
                Reason = "Given expression is updated with multiple expression Then it should return changed expression",
                Expression = x => Apply.This(x, ExampleExpressions.NameAssertion) &&
                                  Apply.This(x, ExampleExpressions.SurnameAssertion) &&
                                  Apply.This(x, ExampleExpressions.AgeAssertion),
                Expected = x => x.Name.StartsWith("someone") &&
                                x.Surname.StartsWith("something") &&
                                x.Age > 18
            };
        }
    }
}