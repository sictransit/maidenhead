using System;
using System.Linq;

namespace Maidenhead
{
    class Program
    {
        static void Main(string[] args)
        {
            var locator = (args.FirstOrDefault() ?? "JO89UT56XU42").ToUpperInvariant();

            Console.WriteLine(locator);

            var c = Maidenhead.Convert(locator);

            Console.WriteLine(c.PrettyPrint());
        }
    }
}
