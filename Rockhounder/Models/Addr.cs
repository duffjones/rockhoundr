using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Addr
    {
        public int Gid { get; set; }
        public long? Tlid { get; set; }
        public string Fromhn { get; set; }
        public string Tohn { get; set; }
        public string Side { get; set; }
        public string Zip { get; set; }
        public string Plus4 { get; set; }
        public string Fromtyp { get; set; }
        public string Totyp { get; set; }
        public int? Fromarmid { get; set; }
        public int? Toarmid { get; set; }
        public string Arid { get; set; }
        public string Mtfcc { get; set; }
        public string Statefp { get; set; }
    }
}
