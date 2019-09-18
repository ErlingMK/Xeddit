using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.ViewModels.Interfaces;

namespace Xeddit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditPage : ContentPage
    {
        private readonly ISubredditViewModel m_subredditViewModel;

        public SubredditPage(ISubredditViewModel subredditViewModel)
        {
            InitializeComponent();

            BindingContext = m_subredditViewModel = subredditViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_subredditViewModel.Initialize();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            SubredditSearchEntry.IsVisible = true;
        }
    }
}