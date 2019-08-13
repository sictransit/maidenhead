using System;
using System.Linq;

namespace Maidenhead
{
    class Program
    {
        static void Main(string[] args)
        {
            var locator = (args.FirstOrDefault() ?? "JO89UT56XU42");

            Console.WriteLine(locator);

            var coordinate = MaidenheadConverter.Convert(locator);

            Console.WriteLine(coordinate.PrettyPrint());
        }
    }
}
