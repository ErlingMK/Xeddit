using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Commands;
using DIPS.Xamarin.UI.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;
using Xeddit.DataModels.Things.Contracts;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t3
    /// </summary>
    public class Link : Thing, ILink
    {
        private string m_author;
        private string m_subreddit;
        private bool m_isExpanded;

        public string Author
        {
            get => $"u/{m_author}";
            set => m_author = value;
        }

        public string Domain { get; set; }
        public bool IsSelf { get; set; }
        public int NumComments { get; set; }
        public bool Over18 { get; set; }
        public int Score { get; set; }
        public string SelfText { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string PrefixedSubreddit { get; set; }

        public string Subreddit { get; set; }

        public string SubredditId { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public long Created { get; set; }
        public long CreatedUtc { get; set; }
        public string Permalink { get; set; }

        public bool IsExpanded
        {
            get => m_isExpanded;
            set => PropertyChanged.RaiseWhenSet(ref m_isExpanded, value);
        }

        public bool HasThumbnail => Thumbnail != "self" && Thumbnail != "default" && Thumbnail != "image";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
