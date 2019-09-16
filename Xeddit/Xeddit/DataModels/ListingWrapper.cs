using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.DataModels
{
    public class ListingWrapper
    {
        public string Kind { get; set; } // Should always be a Listing
        public Listing Data { get; set; }
    }
}
