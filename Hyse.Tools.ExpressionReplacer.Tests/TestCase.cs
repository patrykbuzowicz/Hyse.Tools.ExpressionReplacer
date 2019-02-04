using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    public class TestCase
    {
        public Expression<Func<ExampleModel, object>> Expression { get; set; }
        public Expression<Func<ExampleModel, object>> Expected { get; set; }
        public string Reason { get; set; }

        public override string ToString() => Reason;
    }
}