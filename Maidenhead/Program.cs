using CommandLine;
using Serilog;
using Serilog.Core;
using System;
using System.Linq;

namespace Maidenhead
{
    class Program
    {
        static void Main(string[] args)
        {
            var logLevel = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Information);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(logLevel)
                .WriteTo.Console()
                .CreateLogger();

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                       if (o.Verbose)
                       {
                           logLevel.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                       }

                       if (!string.IsNullOrWhiteSpace(o.Maidenhead))
                       {
                           DecodeMaidenhead(o.Maidenhead);
                       }

                       if (!string.IsNullOrWhiteSpace(o.GeoHash))
                       {
                           DecodeGeoHash(o.GeoHash);
                       }
                   });
        }

        private static void DecodeMaidenhead(string locator)
        {
            Log.Information($"Decoding: {locator}");

            var coordinate = MaidenheadConverter.Convert(locator);

            Log.Information($"Coordinates: {coordinate.PrettyPrint()}");
        }

        private static void DecodeGeoHash(string hash)
        {
            Log.Information($"Decoding: {hash}");

            var box = GeoHashConverter.Convert(hash);

            Log.Information($"Min: {box.Min.PrettyPrint()}");
            Log.Information($"Max: {box.Max.PrettyPrint()}");
        }
    }
}
