namespace Physics.NET.Utility
{
    public static partial class Extensions
    {
        /// <summary>
        /// Complex value in the form a + ib.
        /// </summary>
        /// <param name="re"></param>
        /// <param name="im"></param>
        /// <returns>A complex value as a string in the form a + ib.</returns>
        private static string ComplexToString(double re, double im)
        {
            if (im != 0 && re != 0)
            {
                return $"{re} {GetImString(im)}";
            }

            if (im != 0 && re == 0)
            {
                return im >= 0 ? GetImString(im)[2..] : "-" + GetImString(im)[2..];
            }

            return $"{re}";

            static string GetImString(double im)
            {
                string imString = im.ToString();
                if (im >= 0)
                {
                    return imString == "1" ? $"+ i" : $"+ i{imString}";
                }
                else
                {
                    return imString == "-1" ? $"- i" : $"- i{imString[1..]}";
                }
            }
        }
    }
}
