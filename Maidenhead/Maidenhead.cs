using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Maidenhead
{
    public static class Maidenhead
    {
        public static GeoCoordinate Convert(string locator)
        {
            if (locator is null)
            {
                throw new ArgumentNullException(nameof(locator));
            }

            var c = new GeoCoordinate(-90, -180);

            var longDivisor = 1d;
            var latDivisor = 1d;

            var cnt = 0;

            foreach (var pair in Split(locator.ToUpperInvariant()))
            {
                cnt++;

                if (cnt == 1)
                {
                    longDivisor *= 18;
                    latDivisor *= 18;

                    if (!Regex.IsMatch(pair, @"^[A-R]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else if (cnt % 2 == 0)
                {
                    longDivisor *= 10;
                    latDivisor *= 10;

                    if (!Regex.IsMatch(pair, @"^[0-9]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else
                {
                    longDivisor *= 24;
                    latDivisor *= 24;

                    if (!Regex.IsMatch(pair, @"^[A-X]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }

                int longValue = pair[0] - (cnt % 2 != 0 ? 'A' : '0');
                int latValue = pair[1] - (cnt % 2 != 0 ? 'A' : '0');

                c.Longitude += (360d * longValue) / longDivisor;
                c.Latitude += (180d * latValue) / latDivisor;
            }

            return c;
        }

        private static IEnumerable<string> Split(string s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.Length % 2 != 0)
            {
                throw new ArgumentException("Length must be a multiple of two.", nameof(s));
            }

            return Enumerable.Range(0, s.Length / 2).Select(i => s.Substring(i * 2, 2));
        }
    }
}
