using System;

namespace ASP.Server.Controllers
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
