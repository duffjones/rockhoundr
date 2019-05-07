using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class County
    {
        public int Gid { get; set; }
        public string Statefp { get; set; }
        public string Countyfp { get; set; }
        public string Countyns { get; set; }
        public string Cntyidfp { get; set; }
        public string Name { get; set; }
        public string Namelsad { get; set; }
        public string Lsad { get; set; }
        public string Classfp { get; set; }
        public string Mtfcc { get; set; }
        public string Csafp { get; set; }
        public string Cbsafp { get; set; }
        public string Metdivfp { get; set; }
        public string Funcstat { get; set; }
        public long? Aland { get; set; }
        public double? Awater { get; set; }
        public string Intptlat { get; set; }
        public string Intptlon { get; set; }
    }
}
