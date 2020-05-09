using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.DataViewModels
{
    public class SubredditViewModel : ISubredditViewModel
    {
        public SubredditViewModel(int? accountsActive, string description, string displayName, long subscribers, string title, string url, string displayNamePrefixed)
        {
            AccountsActive = accountsActive;
            Description = description;
            DisplayName = displayName;
            Subscribers = subscribers;
            Title = title;
            Url = url;
            DisplayNamePrefixed = displayNamePrefixed;
        }

        public int? AccountsActive { get; }
        public string Description { get; }
        public string DisplayName { get; }
        public long Subscribers { get; }
        public string Title { get; }
        public string Url { get; }
        public string DisplayNamePrefixed { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
