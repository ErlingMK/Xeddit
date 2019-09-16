using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things;

namespace Xeddit.DataModels
{
    public class ThingWrapper
    {
        public string Kind { get; set; }
        public object Data { get; set; } // Can be a Link, Comment etc. THINGS
    }
}
