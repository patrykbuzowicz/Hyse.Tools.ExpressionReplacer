using System.Linq;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionComparer.Equality
{
    internal class ExpressionComparer
    {
        public static bool Compare(Expression x, Expression y)
        {
            var visitorX = new ExpressionEqualityCollectorVisitor();
            var visitorY = new ExpressionEqualityCollectorVisitor();

            visitorX.Visit(x);
            visitorY.Visit(y);

            if (visitorX.ExpressionEquals.Count != visitorY.ExpressionEquals.Count)
                return false;

            return visitorX.ExpressionEquals
                .Zip(visitorY.ExpressionEquals, (xEquals, yEquals) => new {xEquals, yEquals})
                .All(equals => equals.xEquals.Equals(equals.yEquals));
        }
    }
}
