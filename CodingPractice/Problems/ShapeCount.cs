using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodingPractice
{
    [TestClass]
    public class ShapeCount : ProblemBaseT<bool[,], int>
    {
        public override string Title => "Count Shapes";

        public override string Description =>
            "Given a boolean matrix count islands and number of different shapes. "+
            "Two islands are of the same shape if they mapped by a translation.";

        protected override IEnumerable<Tuple<bool[,], int>> TestCases
        {
            get
            {
                yield return new Tuple<bool[,], int>(new bool[2, 2] { { true, false }, { false, true } }, 2);
            }
        }

        private bool[,] matrix;
        private int M, N;

        public override int Solve(bool[,] matrix)
        {
            this.matrix = matrix;
            M = matrix.GetLength(0);
            N = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    if (matrix[i, j])
                    {
                        paint(i, j);
                        count++;
                    }

            return count;
        }

        private void paint(int i, int j)
        {
            matrix[i, j] = false;
            if (i > 0 && matrix[i - 1, j])
                paint(i - 1, j);
            if (j > 0 && matrix[i, j - 1])
                paint(i, j - 1);
            if (i < M && matrix[i + 1, j])
                paint(i + 1, j);
            if (j < N && matrix[i, j + 1])
                paint(i, j + 1);
        }
    }
}