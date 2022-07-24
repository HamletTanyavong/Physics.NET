namespace Physics.NET.QFT
{
    /// <summary>
    /// General QFT operations.
    /// </summary>
    public static partial class QFT
    {
        /// <summary>
        /// Pauli x matrix.
        /// </summary>
        public static readonly MatSq2 PauliX = new(new Complex[2, 2]
        {
            { 0, 1 },
            { 1, 0 }
        });
        
        /// <summary>
        /// Pauli y matrix.
        /// </summary>
        public static readonly MatSq2 PauliY = new(new Complex[2, 2]
        {
            {  0, -Im },
            { Im,   0 }
        });

        /// <summary>
        /// Pauli z matrix.
        /// </summary>
        public static readonly MatSq2 PauliZ = new(new Complex[2, 2]
        {
            { 1,  0 },
            { 0, -1 }
        });

        /// <summary>
        /// Set of Pauli matricies, with first element being the identity matrix.
        /// </summary>
        public static readonly MatSq2[] Pauli = { Identity.MatSq2, PauliX, PauliY, PauliZ };
    }
}
