using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodingPractice
{
    public abstract class ProblemBase
    {
        public abstract string Title { get; }

        public abstract string Description { get; }
    }

    public abstract class ProblemBaseT<TIn, TOut> : ProblemBase
    {
        protected abstract IEnumerable<Tuple<TIn, TOut>> TestCases { get; }

        public abstract TOut Solve(TIn input);

        [TestMethod]
        public void Test()
        {
            foreach (Tuple<TIn, TOut> tuple in TestCases)
            {
                TOut result = Solve(tuple.Item1);
                Assert.AreEqual(tuple.Item2, result);
            }
        }
    }
}
