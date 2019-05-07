using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Cousub
    {
        public int Gid { get; set; }
        public string Statefp { get; set; }
        public string Countyfp { get; set; }
        public string Cousubfp { get; set; }
        public string Cousubns { get; set; }
        public string Cosbidfp { get; set; }
        public string Name { get; set; }
        public string Namelsad { get; set; }
        public string Lsad { get; set; }
        public string Classfp { get; set; }
        public string Mtfcc { get; set; }
        public string Cnectafp { get; set; }
        public string Nectafp { get; set; }
        public string Nctadvfp { get; set; }
        public string Funcstat { get; set; }
        public decimal? Aland { get; set; }
        public decimal? Awater { get; set; }
        public string Intptlat { get; set; }
        public string Intptlon { get; set; }
    }
}
