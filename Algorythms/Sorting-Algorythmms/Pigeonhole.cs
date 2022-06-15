using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorythmms
{
    internal static class Pigeonhole
    {
        internal static int[] Sort(int[] ints)
        {
            int min = ints.Min();
            int max = ints.Max();
            int range = max - min + 1;
            List<int>[] pigeonholes = new List<int>[range];
            for (int i = 0; i < pigeonholes.Length; i++)
            {
                pigeonholes[i] = new List<int>();
            }
            foreach (int i in ints)
            {
                pigeonholes[i - min].Add(i);
            }
            int index = 0;
            foreach (List<int> hole in pigeonholes)
            {
                foreach (int num in hole)
                {
                    ints[index] = num;
                    index++;
                }
            }
            return ints;
        }
    }
}
