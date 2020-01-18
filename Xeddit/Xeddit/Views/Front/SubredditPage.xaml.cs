using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Views.Comments;

namespace Xeddit.Views.Front
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditPage : ContentPage
    {
        private readonly CommentsPage m_commentsPage;
        private readonly ISubredditViewModel m_subredditViewModel;

        public SubredditPage(ISubredditViewModel subredditViewModel, CommentsPage commentsPage)
        {
            m_commentsPage = commentsPage;
            InitializeComponent();

            BindingContext = m_subredditViewModel = subredditViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_subredditViewModel.Initialize();
        }

        private void SearchItem_OnClicked(object sender, EventArgs e)
        {
            m_subredditViewModel.SearchEntryIsVisible = true;
            SubredditSearchEntry.Focus();
        }

        private void SelectionChanged_NavigateTo(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(m_commentsPage);
        }
    }
}