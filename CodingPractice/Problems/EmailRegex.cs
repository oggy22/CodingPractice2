using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CodingPractice.Problems
{
    [TestClass]
    public class EmailRegex : ProblemBaseT<string, bool>
    {
        public override string Description => "Email regex";

        public override string Title => "Email regex";

        protected override IEnumerable<Tuple<string, bool>> TestCases
        {
            get
            {
                yield return new Tuple<string, bool>("oggy@gmail.com", true);
                yield return new Tuple<string, bool>("oggy@gmail", false);
                yield return new Tuple<string, bool>("oggy@gmail@oggy", false);
                yield return new Tuple<string, bool>("oggy@gmail.com@oggy", false);
            }
        }

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
    }
}
