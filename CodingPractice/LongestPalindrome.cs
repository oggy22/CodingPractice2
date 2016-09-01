﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingPractice
{
    [TestClass]
    public class LongestPalindrome : ProblemBase
    {
        public override string Title => "Longest Palindrome";

        public override string Description => "Given a string find the longest palindrome which is a subsequence";

        public override Type Input => typeof(string);

        public override Type Output => typeof(string);

        public string solve(string input)
        {
            int n = input.Length;
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
                matrix[i, i] = 1;
            for (int i = 1; i < n; i++)
                matrix[i - 1, i] = input[i - 1] == input[i] ? 2 : 1;

            for (int dist = 2; dist<n; dist++)
                for (int i=0; i+dist<n; i++)
                {
                    int j = i + dist;
                    if (input[i] == input[j])
                        matrix[i, j] = 2 + matrix[i + 1, j - 1];
                    else
                        matrix[i, j] = Math.Max(matrix[i + 1, j], matrix[i, j - 1]);
                }

            string left = "", right = "";
            for (int i = 0, j = n - 1; ;)
            {
                if (input[i] == input[j])
                {
                    left = left + input[i];
                    right = input[j] + right;
                    i++;
                    j--;
                }
                else if (matrix[i + 1, j] > matrix[i, j - 1])
                {
                    i++;
                }
                else
                {
                    j--;
                }

                if (i == j)
                    return left + input[i] + right;
                if (i>j)
                    return left + right;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("aba", solve("12ab345a"));
            Assert.AreEqual("abba", solve("abba"));
        }
    }
}