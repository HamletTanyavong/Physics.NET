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
            string result = "{ ";
            result += String.Join(", ", array);
            result = result[..^1];
            return result += " }";
        }

        /// <summary>
        /// Create a set from an <paramref name="array"/> of complex numbers in the form of a string.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Output(this Complex[] array)
        {
            string result = "{";
            for (int i = 0; i < array.Length; i++)
            {
                string sign;
                string im = array[i].Imaginary.ToString();
                if (array[i].Imaginary >= 0)
                {
                    sign = "+";
                }
                else
                {
                    sign = "-";
                    im = im[1..];
                }
                result += $"{array[i].Real}{sign}i{im},";
            }
            result = result[..^1];
            return result += "}";
        }

        public static string Output<T>(this T[,] array) where T : struct, IEquatable<T>, IFormattable
        {
            int m = array.GetLength(0);
            int n = array.GetLength(1);

            int[] rowLengths = GetMaxRowLengths(array, m, n);
            string[] hold = new string[n];

            string result = String.Empty;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    hold[j] = array[i, j]!.ToString()!.PadLeft(rowLengths[j]);
                }
                result += String.Join(", ", hold);
                result += $"\n";
            }
            return result[..^1];

            static int[] GetMaxRowLengths<S>(S[,] array, int m, int n)
            {
                int[] result = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int maxLength = array[0, i]!.ToString()!.Length;
                    for (int j = 1; j < m; j++)
                    {
                        int length = array[j, i]!.ToString()!.Length;
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
