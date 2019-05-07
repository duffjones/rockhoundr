using System;
using System.Collections.Generic;

namespace RockHoundr.Models
{
    public partial class LoaderLookuptables
    {
        public int ProcessOrder { get; set; }
        public string LookupName { get; set; }
        public string TableName { get; set; }
        public bool? SingleMode { get; set; }
        public bool? Load { get; set; }
        public bool LevelCounty { get; set; }
        public bool LevelState { get; set; }
        public bool LevelNation { get; set; }
        public string PostLoadProcess { get; set; }
        public bool? SingleGeomMode { get; set; }
        public char InsertMode { get; set; }
        public string PreLoadProcess { get; set; }
        public string[] ColumnsExclude { get; set; }
        public string WebsiteRootOverride { get; set; }
    }
}
