using System;
using System.Collections.Generic;
using System.Text;

namespace Maidenhead
{
    public class HashBox
    {
        public HashBox(GeoCoordinate min, GeoCoordinate max)
        {
            Min = min ?? throw new ArgumentNullException(nameof(min));
            Max = max ?? throw new ArgumentNullException(nameof(max));
        }

        public GeoCoordinate Min { get; set; }

        public GeoCoordinate Max { get; set; }
    }
}
