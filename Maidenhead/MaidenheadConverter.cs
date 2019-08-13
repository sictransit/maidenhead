using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Maidenhead
{
    public static class MaidenheadConverter
    {
        public static GeoCoordinate Convert(string locator)
        {
            if (locator is null)
            {
                throw new ArgumentNullException(nameof(locator));
            }

            if (!IsValid(locator))
            {
                throw new ArgumentException(nameof(locator));
            }

            var c = new GeoCoordinate(-90, -180);

            var longDivisor = 1d;
            var latDivisor = 1d;

            var cnt = 0;

            foreach (var pair in Split(locator.ToUpperInvariant()))
            {
                cnt++;

                var isLetter = true;

                if (cnt == 1)
                {
                    longDivisor *= 18;
                    latDivisor *= 18;                   
                }
                else if (cnt % 2 == 0)
                {
                    longDivisor *= 10;
                    latDivisor *= 10;
                    isLetter = false;
                }
                else
                {
                    longDivisor *= 24;
                    latDivisor *= 24;                   
                }

                int longValue = pair[0] - (isLetter ? 'A' : '0');
                int latValue = pair[1] - (isLetter ? 'A' : '0');

                c.Longitude += (360d * longValue) / longDivisor;
                c.Latitude += (180d * latValue) / latDivisor;
            }

            return c;
        }

        public static bool IsValid(string locator)
        {
            try
            {
                var _ = Split(locator.ToUpperInvariant()).ToList();             
            }
            catch {
                return false;
            }

            return true;
        }

        private static IEnumerable<string> Split(string locator)
        {
            if (locator is null)
            {
                throw new ArgumentNullException(nameof(locator));
            }

            if (string.IsNullOrEmpty(locator) || locator.Length % 2 != 0)
            {
                throw new ArgumentException("Length must be >0 and even.", nameof(locator));
            }

            return Enumerable.Range(0, locator.Length / 2).Select(i => locator.Substring(i * 2, 2)).Select((p, i) =>
            {
                if (i == 0)
                {
                    if (!Regex.IsMatch(p, @"^[A-R]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else if (i % 2 != 0)
                {
                    if (!Regex.IsMatch(p, @"^[0-9]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else
                {
                    if (!Regex.IsMatch(p, @"^[A-X]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }

                return p;
            });
        }
    }
}
