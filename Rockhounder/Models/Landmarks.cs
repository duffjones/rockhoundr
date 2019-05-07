using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class Landmarks
    {
        public int Gid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DateBuilt { get; set; }
        public string Architect { get; set; }
        public string Landmark { get; set; }
    }
}
