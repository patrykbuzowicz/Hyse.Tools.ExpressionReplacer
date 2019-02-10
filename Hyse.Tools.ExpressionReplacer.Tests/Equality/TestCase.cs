using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Equality
{
    public class TestCase
    {
        public Expression<Func<ExampleModel, object>> Left { get; set; }
        public Expression<Func<ExampleModel, object>> Right { get; set; }
        public bool Expected { get; set; }
    }
}