using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things;

namespace Xeddit.DataModels
{
    public class ThingWrapper
    {
        public string Kind { get; set; }
        public Link Data { get; set; } // Can be a Link, Comment etc. THINGS
    }
}
