using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class LoaderPlatform
    {
        public string Os { get; set; }
        public string DeclareSect { get; set; }
        public string Pgbin { get; set; }
        public string Wget { get; set; }
        public string UnzipCommand { get; set; }
        public string Psql { get; set; }
        public string PathSep { get; set; }
        public string Loader { get; set; }
        public string EnvironSetCommand { get; set; }
        public string CountyProcessCommand { get; set; }
    }
}
