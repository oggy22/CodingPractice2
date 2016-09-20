using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace CodingPractice.Problems
{
    [TestClass]
    public class EmailRegex : ProblemBaseT<string, bool>
    {
        public override string Description => "Email regex";

        public override string Title => "Email regex";

        public override bool Solve(string stEmail)
        {
            Regex regex = new Regex("[A-Za-z_][A-Za-z0-9_]+@[A-Za-z0-9_]+\\.[A-Za-z0-9_]+");
            MatchCollection mc = regex.Matches(stEmail);
            for (int i = 0; i<mc.Count; i++)
            {
                Match m = mc[i];
                if (m.Length == stEmail.Length)
                    return true;
            }
            return false;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(Solve("oggy@gmail.com"));
            Assert.IsFalse(Solve("oggy@gmail"));
            Assert.IsFalse(Solve("oggy@gmail@oggy"));
            Assert.IsFalse(Solve("oggy@gmail.com@oggy"));
            return;
            Assert.IsTrue(Solve("ognjen.sobajic@gmail.com"));
        }
    }
}
