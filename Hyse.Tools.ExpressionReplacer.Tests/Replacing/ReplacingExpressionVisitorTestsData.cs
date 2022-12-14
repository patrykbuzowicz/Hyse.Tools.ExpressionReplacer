using System.Collections.Generic;

namespace Hyse.Tools.ExpressionReplacer.Tests.Replacing
{
    public class ReplacingExpressionVisitorTestsData : TestsDataBase<TestCase>
    {
        protected override IEnumerable<TestCase> GetCases()
        {
            yield return new TestCase
            {
                Reason = "Given simple expression as static field then it should apply the expression",
                Expression = x => Apply.This(x.Surname, ExampleExpressions.TwoLastChars),
                Expected = x => x.Surname.Substring(x.Surname.Length - 2)
            };

            yield return new TestCase
            {
                Reason = "Given super simple expression as static field then it should apply the expression",
                Expression = x => Apply.This(x, ExampleExpressions.AgeAssertion),
                Expected = x => x.Age > 18
            };

            yield return new TestCase
            {
                Reason = "Given more complex expression as static field then it should apply the expression",
                Expression = x => Apply.This(x, ExampleExpressions.TwoStringFieldsAssertion),
                Expected = x => x.Name.Substring(0, 1) == x.Surname.Substring(x.Surname.Length - 1)
            };

            yield return new TestCase
            {
                Reason = "Given two applies ANDed then it should apply expression",
                Expression = x => Apply.This(x, ExampleExpressions.NameAssertion) &&
                                  Apply.This(x, ExampleExpressions.SurnameAssertion),
                Expected = x => x.Name.StartsWith("someone") &&
                                x.Surname.StartsWith("something")
            };

            yield return new TestCase
            {
                Reason = "Given inline expression ORed with applied expression then it should apply expression",
                Expression = x => x.Name + x.Surname == "testing" ||
                                  Apply.This(x, ExampleExpressions.AgeAssertion),
                Expected = x => x.Name + x.Surname == "testing" ||
                                x.Age > 18
            };

            // ReSharper disable ArrangeRedundantParentheses
            yield return new TestCase
            {
                Reason = "Given expression with AND to apply then it should apply the expression",
                Expression = x => x.Age == 20 && Apply.This(x, ExampleExpressions.NameAndSurnameAssertion),
                Expected = x => x.Age == 20 && (x.Name.EndsWith("John") &&
                                                x.Surname.StartsWith("Doe"))
            };
            // ReSharper restore ArrangeRedundantParentheses

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

            yield return new TestCase
            {
                Reason = "Inserts expression into ternary operator",
                Expression = x => Apply.This(x, ExampleExpressions.AgeAssertion) ? "adult" : "underage",
                Expected = x => x.Age > 18 ? "adult" : "underage",
            };
        }
    }
}