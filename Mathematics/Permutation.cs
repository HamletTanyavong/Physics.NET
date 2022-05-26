using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics
{
    /// <summary>
    /// Calculates the permutation of a number of integers.
    /// </summary>
    [Obsolete("method not ready for implementation")]
    public class Permutation
    {
        private static int N { get; set; }

        public Permutation(int n)
        {
            N = n;
        }

        /// <summary>
        /// Calculates the <paramref name="j"/>th permutation of a sequence.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public int[] Sequence(int j)
        {
            int[] result = new int[N];
            for (int l = 1; l <= N; l++)
            {
                var sum = 0;
                for (int k = 0; k < l - 1; k++)
                {
                    if (Cycle(j, l) >= Cycle(j, k + 1))
                    {
                        sum += 1;
                    }
                    else
                    {
                        ;
                    }
                }
                result[l - 1] = Cycle(j, l) + sum;
                //Console.WriteLine(sum);
            }
            return result;
        }

        public int Inverse(int[] sequence)
        {
            return int.MaxValue;
        }

        private static int Cycle(int j, int l)
        {
            return 1 + ((j - 1) / General.Factorial(N - l)) % (N - l + 1);
        }
    }
}
