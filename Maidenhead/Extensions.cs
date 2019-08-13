using System;
using System.Globalization;

namespace Maidenhead
{
    public static class Extensions
    {
        public static string PrettyPrint(this GeoCoordinate c)
        {
            int longDegrees = Math.Abs((int)Math.Truncate(c.Longitude));
            int latDegrees = Math.Abs((int)Math.Truncate(c.Latitude));

            double longMinutes = Math.Abs(c.Longitude % 1) * 60d;
            double latMinutes = Math.Abs(c.Latitude % 1) * 60d;

            var longLabel = c.Longitude > 0 ? "E" : "W";
            var latLabel = c.Latitude > 0 ? "N" : "S";

            var culture = CultureInfo.CreateSpecificCulture("en-US");

            return $"{latLabel} {latDegrees}° {latMinutes.ToString("00.000", culture)} {longLabel} {longDegrees:000}° {longMinutes.ToString("00.000", culture)}";
        }
    }
}
