using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class PagcRules
    {
        public int Id { get; set; }
        public string Rule { get; set; }
        public bool? IsCustom { get; set; }
    }
}
