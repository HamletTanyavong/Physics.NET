namespace Physics.NET.Exceptions
{
    internal class IndexMismatchException : Exception
    {
        public IndexMismatchException()
        {
        }

        public IndexMismatchException(string message)
            : base(message)
        {
        }

        public IndexMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
