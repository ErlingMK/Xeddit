using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.DataModels
{
    /// <summary>
    /// The Reddit base class.
    /// </summary>
    public class Thing
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public object Data { get; set; }
    }
}
