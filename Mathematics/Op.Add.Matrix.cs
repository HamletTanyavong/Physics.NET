namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static MatSq2 Add(MatSq2 a, MatSq2 b)
        {
            MatSq2 result = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static MatSq3 Add(MatSq3 a, MatSq3 b)
        {
            MatSq3 result = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static MatSq4 Add(MatSq4 a, MatSq4 b)
        {
            MatSq4 result = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
    }
}
