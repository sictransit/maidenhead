using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maidenhead
{
    public class Options
    {
        [Option(Required = false, HelpText = "set output to verbose messages")]
        public bool Verbose { get; set; }

        [Option(Required = false, HelpText = "decode Maidenhead locator")]
        public string Maidenhead { get; set; }

        [Option(Required = false, HelpText = "decode GeoHash hash")]
        public string GeoHash { get; set; }
    }
}
