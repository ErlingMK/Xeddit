using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.DataModels.Things
{
    public class More : Thing
    {
        public int Count { get; set; }
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }
        public int Depth { get; set; }
        public List<string> Children { get; set; }
    }
}
