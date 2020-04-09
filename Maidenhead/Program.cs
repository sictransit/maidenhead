using Serilog;
using System;
using System.Linq;

namespace Maidenhead
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var locator = (args.FirstOrDefault() ?? "JO89");

            Log.Information($"Decoding: {locator}");

            var coordinate = MaidenheadConverter.Convert(locator);

            Log.Information($"Coordinates: {coordinate.PrettyPrint()}");
        }
    }
}
