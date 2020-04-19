using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Views.Front.ViewModel;

namespace Xeddit.Views.Front
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditPage : ContentPage
    {

        public SubredditPage(ISubredditViewModel subredditViewModel)
        {
            InitializeComponent();

            BindingContext = subredditViewModel;
        }
    }
}