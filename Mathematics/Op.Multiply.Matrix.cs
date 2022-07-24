namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static MatSq2 Multiply(MatSq2 a, Complex b)
        {
            MatSq2 result = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = b * a[i, j];
                }
            }
            return result;
        }

        public static MatSq2 Multiply(Complex a, MatSq2 b)
        {
            MatSq2 result = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = a * b[i, j];
                }
            }
            return result;
        }

        public static MatSq2 Multiply(MatSq2 a, MatSq2 b)
        {
            MatSq2 result = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j];
                }
            }
            return result;
        }

        public static MatSq3 Multiply(Complex a, MatSq3 b)
        {
            MatSq3 result = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = a * b[i, j];
                }
            }
            return result;
        }

        public static MatSq3 Multiply(MatSq3 a, Complex b)
        {
            MatSq3 result = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = b * a[i, j];
                }
            }
            return result;
        }

        public static MatSq3 Multiply(MatSq3 a, MatSq3 b)
        {
            MatSq3 result = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j];
                }
            }
            return result;
        }

        public static MatSq4 Multiply(Complex a, MatSq4 b)
        {
            MatSq4 result = new();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = a * b[i, j];
                }
            }
            return result;
        }

        public static MatSq4 Multiply(MatSq4 a, Complex b)
        {
            MatSq4 result = new();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = b * a[i, j];
                }
            }
            return result;
        }

        public static MatSq4 Multiply(MatSq4 a, MatSq4 b)
        {
            MatSq4 result = new();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
                }
            }
            return result;
        }
    }
}
