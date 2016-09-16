using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace CodingPractice.Problems
{
    [TestClass]
    public class EmailRegex : ProblemBase
    {
        public override string Description => "Email regex";

        public override Type Input => typeof(string);

        public override Type Output => typeof(bool);

        public override string Title => "Email regex";

        public bool solve(string stEmail)
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
            Assert.IsTrue(solve("oggy@gmail.com"));
            Assert.IsFalse(solve("oggy@gmail"));
            Assert.IsFalse(solve("oggy@gmail@oggy"));
            Assert.IsFalse(solve("oggy@gmail.com@oggy"));
            return;

            Assert.IsTrue(solve("ognjen.sobajic@gmail.com"));
        }
    }
}
