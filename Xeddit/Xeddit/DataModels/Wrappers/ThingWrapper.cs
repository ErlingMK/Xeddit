using Xeddit.DataModels.Things;

namespace Xeddit.DataModels.Wrappers
{
    public class ThingWrapper
    {
        public string Kind { get; set; } // t1, t2, t3 etc
        public object Data { get; set; } // Can be a Link, Comment etc. THINGS
    }
}
