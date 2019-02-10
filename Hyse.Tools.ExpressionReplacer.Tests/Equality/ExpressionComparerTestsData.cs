using System.Collections.Generic;
using System.Linq;

namespace Hyse.Tools.ExpressionReplacer.Tests.Equality
{
    public class ExpressionComparerTestsData : List<object[]>
    {
        public ExpressionComparerTestsData()
        {
            AddRange(GetCases().Select(x => new object[] {x}));
        }

        private IEnumerable<TestCase> GetCases()
        {
            yield return new TestCase
            {
                Left = x => x.Name,
                Right = x => x.Name,
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => x.Name,
                Right = x => x.Surname,
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => null,
                Right = x => null,
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => x.Name,
                Right = x => null,
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => 50,
                Right = x => 50,
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => 50,
                Right = x => 40,
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => 50,
                Right = x => x.Age,
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => x.Name == "" && x.Surname == "",
                Right = x => x.Name == "" && x.Surname == "",
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => x.Name == "" && x.Surname == "",
                Right = x => x.Name == "" || x.Surname == "",
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => x.Surname.Substring(2),
                Right = x => x.Surname.Substring(2),
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => x.Surname.Substring(2),
                Right = x => x.Surname.Substring(3),
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => x.Surname.StartsWith("x"),
                Right = x => x.Surname.EndsWith("x"),
                Expected = false
            };
        }
    }
}