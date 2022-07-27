namespace Physics.NET.Utility
{
    public static partial class Extensions
    {
        /// <summary>
        /// Create a set from an <paramref name="array"/> of numbers in the form of a string.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Output<T>(this T[] array)
        {
            string result = "[";
            result += String.Join(", ", array);
            result = result[..^1];
            return result += "]";
        }

        /// <summary>
        /// Create a set from an <paramref name="array"/> of complex numbers in the form of a string.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Output(this Complex[] array)
        {
            string result = "[";
            string[] hold = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double rePart = array[i].Real;
                double imPart = array[i].Imaginary;
                hold[i] = ComplexToString(rePart, imPart);
            }
            result += String.Join(", ", hold);
            return result += "]";
        }

        public static string Output<T>(this T[,] array) where T : struct, IEquatable<T>, IFormattable
        {
            int m = array.GetLength(0);
            int n = array.GetLength(1);

            int maxRowLength = GetMaxRowLength(array, m, n);
            string[] hold = new string[n];

            string result = String.Empty;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    hold[j] = array[i, j]!.ToString()!.PadRight(maxRowLength);
                }
                hold[0] = (i != 0 ? " [" : "[[") + hold[0];
                hold[n - 1] += i != m - 1 ? "]," : "]]";
                result += String.Join(" ", hold);
                result += $"\n";
            }
            return result[..^1];

            static int GetMaxRowLength<S>(S[,] array, int m, int n)
            {
                int result = 1;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var length = array[i, j]!.ToString()!.Length;
                        if (result < length)
                        {
                            result = length;
                        }
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Formats a <paramref name="matrix"/> into a neat string.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>Formatted string of <paramref name="matrix"/> values.</returns>
        public static string Output(this IMatrix matrix)
        {
            int m = matrix.M;
            int n = matrix.N;

            int[] rowLengths = GetMaxRowLengths(matrix, m, n);
            string[] hold = new string[n];

            string result = String.Empty;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var z = matrix[i, j];
                    hold[j] = ComplexToString(z.Real, z.Imaginary).PadLeft(rowLengths[j]);
                }
                hold[0] = (i != 0 ? " [" : "[[") + hold[0];
                hold[n - 1] += i != m - 1 ? "]," : "]]";
                result += String.Join(" ", hold);
                result += $"\n";
            }
            return result[..^1];

            static int[] GetMaxRowLengths(IMatrix array, int m, int n)
            {
                int[] result = new int[n];
                for (int i = 0; i < n; i++)
                {
                    var startNum = array[0, i];
                    int maxLength = ComplexToString(startNum.Real, startNum.Imaginary).Length;
                    for (int j = 1; j < m; j++)
                    {
                        var iterNum = array[j, i];
                        int length = ComplexToString(iterNum.Real, iterNum.Imaginary).Length;
                        if (maxLength < length)
                        {
                            maxLength = length;
                        }
                    }
                    result[i] = maxLength;
                }
                return result;
            }
        }
    }
}
