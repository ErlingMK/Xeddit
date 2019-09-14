using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.DataModels
{
    public class ListingWrapper
    {
        // Should always be Listing
        public string Kind { get; set; }
        public Listing Data { get; set; }
    }
}
