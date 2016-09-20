using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingPractice
{
    [TestClass]
    public class Factorial : ProblemBaseT<int, int>
    {
        public override string Title => "Factorial";

        public override string Description => "Given a number calculate its factorial";

        public override int Solve(int n)
        {
            if (n <= 0)
                return 1;

            int res = 1;
            for (int i = 2; i <= n; i++)
                res *= i;

            return res;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, Solve(0));
            Assert.AreEqual(1, Solve(1));
            Assert.AreEqual(2, Solve(2));
            Assert.AreEqual(6, Solve(3));
            Assert.AreEqual(24, Solve(4));
            Assert.AreEqual(120, Solve(5));
        }
    }
}