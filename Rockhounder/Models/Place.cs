using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Place
    {
        public int Gid { get; set; }
        public string Statefp { get; set; }
        public string Placefp { get; set; }
        public string Placens { get; set; }
        public string Plcidfp { get; set; }
        public string Name { get; set; }
        public string Namelsad { get; set; }
        public string Lsad { get; set; }
        public string Classfp { get; set; }
        public string Cpi { get; set; }
        public string Pcicbsa { get; set; }
        public string Pcinecta { get; set; }
        public string Mtfcc { get; set; }
        public string Funcstat { get; set; }
        public long? Aland { get; set; }
        public long? Awater { get; set; }
        public string Intptlat { get; set; }
        public string Intptlon { get; set; }
    }
}
