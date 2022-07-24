namespace Physics.NET.QFT
{
    public static partial class QFT
    {
        /// <summary>
        /// Gamma 0 matrix.
        /// </summary>
        public static readonly MatSq4 Gamma0 = new(new Complex[4, 4]
        {
            { 1, 0,  0,  0 },
            { 0, 1,  0,  0 },
            { 0, 0, -1,  0 },
            { 0, 0,  0, -1 }
        });

        /// <summary>
        /// Gamma 1 Matrix.
        /// </summary>
        public static readonly MatSq4 Gamma1 = new(new Complex[4, 4]
        {
            {  0,  0, 0, 1 },
            {  0,  0, 1, 0 },
            {  0, -1, 0, 0 },
            { -1,  0, 0, 0 }
        });

        /// <summary>
        /// Gamma 2 Matrix.
        /// </summary>
        public static readonly MatSq4 Gamma2 = new(new Complex[4, 4]
        {
            {   0,  0,  0, -Im },
            {   0,  0, Im,   0 },
            {   0, Im,  0,   0 },
            { -Im,  0,  0,   0 }
        });

        /// <summary>
        /// Gamma 3 matrix.
        /// </summary>
        public static readonly MatSq4 Gamma3 = new(new Complex[4, 4]
        {
            {  0, 0, 1,  0 },
            {  0, 0, 0, -1 },
            { -1, 0, 0,  0 },
            {  0, 1, 0,  0 }
        });

        /// <summary>
        /// "Gamma" 5 matrix.
        /// </summary>
        public static readonly MatSq4 Gamma5 = new(new Complex[4, 4]
        {
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 },
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 }
        });

        /// <summary>
        /// Set of Gamma matricies.
        /// </summary>
        public static readonly MatSq4[] Gamma = { Gamma0, Gamma1, Gamma2, Gamma3 };
    }
}
