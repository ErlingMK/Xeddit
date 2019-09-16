using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t5
    /// </summary>
    public class Subreddit : ThingWrapper
    {
        public int AccountsActive { get; private set; }
        public string Description { get; private set; }
        public string DisplayName { get; private set; }
        public long Subscribers { get; private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }

    }
}
