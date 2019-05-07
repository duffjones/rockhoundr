using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class StateLookup
    {
        public int StCode { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string Statefp { get; set; }
    }
}
