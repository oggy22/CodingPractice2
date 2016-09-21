using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodingPractice
{
    [TestClass]
    public class Factorial : ProblemBaseT<int, int>
    {
        public override string Title => "Factorial";

        public override string Description => "Given a number calculate its factorial";

        protected override IEnumerable<Tuple<int, int>> TestCases
        {
            get
            {
                yield return new Tuple<int, int>(0, 1);
                yield return new Tuple<int, int>(1, 1);
                yield return new Tuple<int, int>(2, 2);
                yield return new Tuple<int, int>(3, 6);
                yield return new Tuple<int, int>(4, 24);
                yield return new Tuple<int, int>(5, 120);
            }
        }

        public override int Solve(int n)
        {
            if (n <= 0)
                return 1;

            int res = 1;
            for (int i = 2; i <= n; i++)
                res *= i;

            return res;
        }
    }
}