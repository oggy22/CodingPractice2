using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingPractice
{
    [TestClass]
    public class Factorial : ProblemBase
    {
        public override string Description => "Given a number calculate its factorial";

        public override Type Input => typeof(string);

        public override Type Output => typeof(string);

        public int solve(int n)
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
            Assert.AreEqual(1, solve(0));
            Assert.AreEqual(1, solve(1));
            Assert.AreEqual(2, solve(2));
            Assert.AreEqual(6, solve(3));
            Assert.AreEqual(24, solve(4));
            Assert.AreEqual(120, solve(5));
        }
    }
}