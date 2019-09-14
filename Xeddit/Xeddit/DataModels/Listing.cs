using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.DataModels
{
    public class Listing
    {
        public string Before { get; set; }
        public string After { get; set; }
        public string ModHash { get; set; }
        public IList<Thing> Children { get; set; }
    }
}
