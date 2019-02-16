using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hyse.Tools.ExpressionReplacer.Tests.Replacing
{
    public abstract class TestsDataBase<T> : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return GetCases().Select(x => new object[] {x}).GetEnumerator();
        }

        protected abstract IEnumerable<T> GetCases();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}