using System;
using System.Collections.Generic;
using System.Linq;

namespace Hyse.Tools.ExpressionComparer.Tests.Equality
{
    public class ExpressionComparerTestsData : List<object[]>
    {
        public ExpressionComparerTestsData()
        {
            AddRange(GetCases().Select(x => new object[] { x }));
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

            yield return new TestCase
            {
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1)),
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1)),
                Expected = true
            };

            yield return new TestCase
            {
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1)),
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1) + 2),
                Expected = false
            };

            yield return new TestCase
            {
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1) + 2),
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1) + 2),
                Expected = true
            };

            yield return new TestCase
            {
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1)),
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1, StringComparison.Ordinal)),
                Expected = false
            };

            yield return new TestCase
            {
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1, StringComparison.Ordinal)),
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1, StringComparison.Ordinal)),
                Expected = true
            };

            yield return new TestCase
            {
                Left = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1, StringComparison.Ordinal)),
                Right = x => x.Name.Substring(x.Name.IndexOf(x.Surname + 1, StringComparison.OrdinalIgnoreCase)),
                Expected = false
            };

            yield return new TestCase
            {
                // ReSharper disable once NegativeEqualityExpression
                Left = x => !(x.Name == "test1"),
                // ReSharper disable once NegativeEqualityExpression
                Right = x => !(x.Name == "test2"),
                Expected = false
            };
        }
    }
}