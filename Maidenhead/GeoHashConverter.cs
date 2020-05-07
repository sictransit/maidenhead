using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maidenhead
{
    public static class GeoHashConverter
    {
        private const string GH32ghs = "0123456789bcdefghjkmnpqrstuvwxyz";

        private static readonly Dictionary<char, int> Base32Codes = GH32ghs.ToDictionary(x => x, x => GH32ghs.IndexOf(x));

        public static HashBox Convert(string hash)
        {
            if (hash is null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            if (!hash.All(c => GH32ghs.Contains(c)))
            {
                throw new ArgumentOutOfRangeException(nameof(hash));
            }

            return DecodeBox(hash);
        }

        private static HashBox DecodeBox(string hash)
        {
            var isLongitude = true;

            var min = new GeoCoordinate(-90, -180);
            var max = new GeoCoordinate(90, 180);

            var shifts = new List<int>() { 4, 3, 2, 1, 0 };

            hash.ToList().ForEach(c =>
            {
                shifts.ForEach(shift =>
                {
                    var coordinate = ((Base32Codes[c] >> shift) & 1) == 1 ? min : max;                    

                    if (isLongitude)
                    {
                        coordinate.Longitude = (max.Longitude + min.Longitude) / 2; 
                    }
                    else
                    {
                        coordinate.Latitude = (max.Latitude + min.Latitude) / 2;
                    }

                    isLongitude = !isLongitude;
                });

                Log.Debug($"char: {c} min: {min.PrettyPrint()} max: {max.PrettyPrint()}");
            });

            return new HashBox(min, max);
        }
    }
}
