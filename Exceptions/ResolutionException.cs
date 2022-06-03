namespace Physics.NET.Exceptions
{
    internal class ResolutionException : Exception
    {
        public int Value { get; }

        public ResolutionException()
        {
        }

        public ResolutionException(string message)
            : base(message)
        {
        }

        public ResolutionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ResolutionException(string message, int value)
            : this(message)
        {
            Value = value;
        }
    }
}
