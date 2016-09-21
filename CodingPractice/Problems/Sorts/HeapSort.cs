using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace CodingPractice.Problems.Sorts
{
    [TestClass]
    public class HeapSort : ProblemBaseT<int[], int[]>
    {
        public override string Description => "Heap sort implementation";

        public override string Title => "Heap sort implementation";

        protected override IEnumerable<Tuple<int[], int[]>> TestCases
        {
            get
            {
                yield break;
            }
        }

        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void MaxHeapifyOld(int[] array, int n)
        {
            for (int i=n-1; i>0; i--)
            {
                int pos = i;
                int next = (i - 1) / 2;
                while (pos > 0 && array[pos] > array[next])
                {
                    swap(array, pos, next);
                    pos = next;
                    next = (pos - 1) / 2;
                }
            }
        }

        private void Sink(int[] array, int pos, int n)
        {
            n = array.Length;
            int pos1 = 2 * n + 1;
            int pos2 = 2 * n + 2;

            if (array[pos] >= array[pos1] && array[pos] >= array[pos2])
                return;

            if (array[pos1] > array[pos2])
                swap(array, pos1, pos);

        }

        private void MaxHeapify(int[] array, int pos)
        {
            int n = array.Length;
            int pos1 = 2 * pos + 1;
            if (pos1 < n)
                MaxHeapify(array, pos1);

            int pos2 = 2 * pos + 2;
            if (pos2 < n)
                MaxHeapify(array, pos2);

            Sink(array, pos, n);
        }

        private bool IsHeap(int[] array)
        {
            for (int i=0; ; i++)
            {
                int i1 = 2 * i + 1;
                if (i1 >= array.Length)
                    break;
                if (array[i] < array[i1])
                    return false;

                int i2 = 2 * i + 2;
                if (i2 >= array.Length)
                    break;
                if (array[i] < array[i2])
                    return false;
            }

            return true;
        }

        public override int[] Solve(int[] array)
        {
            MaxHeapify(array, array.Length);
            Assert.IsTrue(IsHeap(array));

            for (int i=array.Length-1; i>0; i--)
            {
                swap(array, i, 0);
                MaxHeapify(array, i);
            }

            return array;
        }

        [TestMethod]
        public new void Test()
        {
            base.Test();
            int lenght = 15;
            Random rand = new Random(0);
            int[] array = new int[lenght];
            for (int i = 0; i < lenght; i++)
                array[i] = rand.Next(20);
            int[] arrayCopy = array.Clone() as int[];
            Solve(array);
            Assert.IsTrue(array.IsPermutationOf(arrayCopy));
            Assert.IsTrue(array.IsSorted());
        }
    }
}