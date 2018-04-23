using System;
using System.Globalization;
using System.Linq;

namespace TSpan
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string value = "0:12:12";
            TimeSpan playlistLength = new TimeSpan(0, 1, 0);
            TimeSpan time = new TimeSpan(0, 14, 59);
            var result = time.Subtract(playlistLength);
            Console.WriteLine(result);
            TimeSpan span = TimeSpan.Zero;
            if (TimeSpan.TryParse(value, out span))
            {
                Console.WriteLine(span);
            }
            var result2 = span.Negate();
            Console.WriteLine(result2);
            result2 = result2.Negate();
            Console.WriteLine(result2);
            var zero = TimeSpan.Zero;
            Console.WriteLine(zero);
            string debug = "";


        }
    }
}
