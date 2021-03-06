﻿using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataModels
{
    public class Listing
    {
        public string ModHash { get; set; }
        public int? Dist { get; set; }
        public List<ThingWrapper> Children { get; set; }
        public string After { get; set; }
        public string Before { get; set; }
    }
}
