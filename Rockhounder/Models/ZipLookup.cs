using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class ZipLookup
    {
        public int Zip { get; set; }
        public int? StCode { get; set; }
        public string State { get; set; }
        public int? CoCode { get; set; }
        public string County { get; set; }
        public int? CsCode { get; set; }
        public string Cousub { get; set; }
        public int? PlCode { get; set; }
        public string Place { get; set; }
        public int? Cnt { get; set; }
    }
}
