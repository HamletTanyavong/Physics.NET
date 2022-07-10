namespace Physics.NET.Utility
{
    public static partial class Ut
    {
        public static string ToString(int[] array)
        {
            string result = "{";
            for (int i = 0; i < array.Length; i++)
            {
                result += $"{array[i]},";
            }
            result = result[..^1];
            result += "}";
            return result;
        }
    }
}
