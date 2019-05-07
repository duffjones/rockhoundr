using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Testrocks
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Mineral { get; set; }
        public string Occurence { get; set; }
        public string Raregems { get; set; }
        public int Gid { get; set; }
    }
}
