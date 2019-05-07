using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class ZipLookupBase
    {
        public string Zip { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Statefp { get; set; }
    }
}
