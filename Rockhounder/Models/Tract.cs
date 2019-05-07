using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Tract
    {
        public int Gid { get; set; }
        public string Statefp { get; set; }
        public string Countyfp { get; set; }
        public string Tractce { get; set; }
        public string TractId { get; set; }
        public string Name { get; set; }
        public string Namelsad { get; set; }
        public string Mtfcc { get; set; }
        public string Funcstat { get; set; }
        public double? Aland { get; set; }
        public double? Awater { get; set; }
        public string Intptlat { get; set; }
        public string Intptlon { get; set; }
    }
}
