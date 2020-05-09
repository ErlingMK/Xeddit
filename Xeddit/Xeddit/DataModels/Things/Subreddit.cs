using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xeddit.DataModels.Things.Contracts;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.DataModels.Things
{
    /// <summary>
    /// Type prefix: t5
    /// </summary>
    public class Subreddit : Thing
    {
        //[JsonProperty("user_flair_background_color")]
        //public object UserFlairBackgroundColor { get; set; }

        //[JsonProperty("submit_text_html")]
        //public string SubmitTextHtml { get; set; }

        //[JsonProperty("restrict_posting")]
        //public bool RestrictPosting { get; set; }

        //[JsonProperty("user_is_banned")]
        //public object UserIsBanned { get; set; }

        //[JsonProperty("free_form_reports")]
        //public bool FreeFormReports { get; set; }

        //[JsonProperty("wiki_enabled")]
        //public bool WikiEnabled { get; set; }

        //[JsonProperty("user_is_muted")]
        //public object UserIsMuted { get; set; }

        //[JsonProperty("user_can_flair_in_sr")]
        //public object UserCanFlairInSr { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        //[JsonProperty("header_img")]
        //public object HeaderImg { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("icon_size")]
        //public List<long> IconSize { get; set; }

        //[JsonProperty("primary_color")]
        //public string PrimaryColor { get; set; }

        //[JsonProperty("active_user_count")]
        //public object ActiveUserCount { get; set; }

        //[JsonProperty("icon_img")]
        //public Uri IconImg { get; set; }

        [JsonProperty("display_name_prefixed")]
        public string DisplayNamePrefixed { get; set; }

        [JsonProperty("accounts_active")]
        public int? AccountsActive { get; set; }

        //[JsonProperty("public_traffic")]
        //public bool PublicTraffic { get; set; }

        [JsonProperty("subscribers")]
        public long Subscribers { get; set; }

        //[JsonProperty("user_flair_richtext")]
        //public List<object> UserFlairRichtext { get; set; }

        //[JsonProperty("videostream_links_count")]
        //public long VideostreamLinksCount { get; set; }

        //[JsonProperty("quarantine")]
        //public bool Quarantine { get; set; }

        //[JsonProperty("hide_ads")]
        //public bool HideAds { get; set; }

        //[JsonProperty("emojis_enabled")]
        //public bool EmojisEnabled { get; set; }

        //[JsonProperty("advertiser_category")]
        //public string AdvertiserCategory { get; set; }

        //[JsonProperty("public_description")]
        //public string PublicDescription { get; set; }

        //[JsonProperty("comment_score_hide_mins")]
        //public long CommentScoreHideMins { get; set; }

        //[JsonProperty("user_has_favorited")]
        //public object UserHasFavorited { get; set; }

        //[JsonProperty("user_flair_template_id")]
        //public object UserFlairTemplateId { get; set; }

        //[JsonProperty("community_icon")]
        //public Uri CommunityIcon { get; set; }

        //[JsonProperty("banner_background_image")]
        //public Uri BannerBackgroundImage { get; set; }

        //[JsonProperty("original_content_tag_enabled")]
        //public bool OriginalContentTagEnabled { get; set; }

        //[JsonProperty("submit_text")]
        //public string SubmitText { get; set; }

        //[JsonProperty("description_html")]
        //public string DescriptionHtml { get; set; }

        //[JsonProperty("spoilers_enabled")]
        //public bool SpoilersEnabled { get; set; }

        //[JsonProperty("header_title")]
        //public string HeaderTitle { get; set; }

        //[JsonProperty("header_size")]
        //public object HeaderSize { get; set; }

        //[JsonProperty("user_flair_position")]
        //public string UserFlairPosition { get; set; }

        //[JsonProperty("all_original_content")]
        //public bool AllOriginalContent { get; set; }

        //[JsonProperty("has_menu_widget")]
        //public bool HasMenuWidget { get; set; }

        //[JsonProperty("is_enrolled_in_new_modmail")]
        //public object IsEnrolledInNewModmail { get; set; }

        //[JsonProperty("key_color")]
        //public string KeyColor { get; set; }

        //[JsonProperty("can_assign_user_flair")]
        //public bool CanAssignUserFlair { get; set; }

        //[JsonProperty("created")]
        //public long Created { get; set; }

        //[JsonProperty("wls")]
        //public long Wls { get; set; }

        //[JsonProperty("show_media_preview")]
        //public bool ShowMediaPreview { get; set; }

        //[JsonProperty("submission_type")]
        //public string SubmissionType { get; set; }

        //[JsonProperty("user_is_subscriber")]
        //public object UserIsSubscriber { get; set; }

        //[JsonProperty("disable_contributor_requests")]
        //public bool DisableContributorRequests { get; set; }

        //[JsonProperty("allow_videogifs")]
        //public bool AllowVideogifs { get; set; }

        //[JsonProperty("user_flair_type")]
        //public string UserFlairType { get; set; }

        //[JsonProperty("allow_polls")]
        //public bool AllowPolls { get; set; }

        //[JsonProperty("collapse_deleted_comments")]
        //public bool CollapseDeletedComments { get; set; }

        //[JsonProperty("emojis_custom_size")]
        //public object EmojisCustomSize { get; set; }

        //[JsonProperty("public_description_html")]
        //public string PublicDescriptionHtml { get; set; }

        //[JsonProperty("allow_videos")]
        //public bool AllowVideos { get; set; }

        //[JsonProperty("is_crosspostable_subreddit")]
        //public bool IsCrosspostableSubreddit { get; set; }

        //[JsonProperty("suggested_comment_sort")]
        //public string SuggestedCommentSort { get; set; }

        //[JsonProperty("can_assign_link_flair")]
        //public bool CanAssignLinkFlair { get; set; }

        //[JsonProperty("accounts_active_is_fuzzed")]
        //public bool AccountsActiveIsFuzzed { get; set; }

        //[JsonProperty("submit_text_label")]
        //public string SubmitTextLabel { get; set; }

        //[JsonProperty("link_flair_position")]
        //public string LinkFlairPosition { get; set; }

        //[JsonProperty("user_sr_flair_enabled")]
        //public object UserSrFlairEnabled { get; set; }

        //[JsonProperty("user_flair_enabled_in_sr")]
        //public bool UserFlairEnabledInSr { get; set; }

        //[JsonProperty("allow_discovery")]
        //public bool AllowDiscovery { get; set; }

        //[JsonProperty("user_sr_theme_enabled")]
        //public bool UserSrThemeEnabled { get; set; }

        //[JsonProperty("link_flair_enabled")]
        //public bool LinkFlairEnabled { get; set; }

        //[JsonProperty("subreddit_type")]
        //public string SubredditType { get; set; }

        //[JsonProperty("notification_level")]
        //public object NotificationLevel { get; set; }

        //[JsonProperty("banner_img")]
        //public object BannerImg { get; set; }

        //[JsonProperty("user_flair_text")]
        //public object UserFlairText { get; set; }

        //[JsonProperty("banner_background_color")]
        //public string BannerBackgroundColor { get; set; }

        //[JsonProperty("show_media")]
        //public bool ShowMedia { get; set; }

        //[JsonProperty("user_is_contributor")]
        //public object UserIsContributor { get; set; }

        //[JsonProperty("over18")]
        //public bool Over18 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        //[JsonProperty("submit_link_label")]
        //public string SubmitLinkLabel { get; set; }

        //[JsonProperty("user_flair_text_color")]
        //public object UserFlairTextColor { get; set; }

        //[JsonProperty("restrict_commenting")]
        //public bool RestrictCommenting { get; set; }

        //[JsonProperty("user_flair_css_class")]
        //public object UserFlairCssClass { get; set; }

        //[JsonProperty("allow_images")]
        //public bool AllowImages { get; set; }

        //[JsonProperty("lang")]
        //public string Lang { get; set; }

        //[JsonProperty("whitelist_status")]
        //public string WhitelistStatus { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        //[JsonProperty("created_utc")]
        //public long CreatedUtc { get; set; }

        //[JsonProperty("banner_size")]
        //public object BannerSize { get; set; }

        //[JsonProperty("mobile_banner_image")]
        //public Uri MobileBannerImage { get; set; }

        //[JsonProperty("user_is_moderator")]
        //public object UserIsModerator { get; set; }
    }
}
