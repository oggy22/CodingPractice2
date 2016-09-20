using System;

namespace CodingPractice
{
    public static class Utilities
    {
        public static bool IsSorted<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
                if (array[i - 1].CompareTo(array[i]) > 0)
                    return false;
            return true;
        }

        public static bool IsPermutationOf<T>(this T[] arrayA, T[] arrayB) where T : IComparable<T>
        {
            int n = arrayA.Length;

            if (arrayB.Length != n)
                return false;

            bool[] b = new bool[n];
            for (int i=0; i<n; i++)
            {
                int j;
                for (j=0; j<n; j++)
                {
                    if (!b[j] && arrayA[i].CompareTo(arrayB[j]) == 0)
                    {
                        b[j] = true;
                        break;
                    }
                }

                if (j == n)
                    return false;
            }
            return true;
        }
    }
}
