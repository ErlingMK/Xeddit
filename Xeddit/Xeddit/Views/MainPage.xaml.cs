using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(SubredditPage subredditPage, UserPage userPage)
        {
            InitializeComponent();

            Children.Add(new NavigationPage(subredditPage){Title = "Posts", BarBackgroundColor = Color.DarkGray});
            Children.Add(new NavigationPage(userPage){Title = "User",  BarBackgroundColor = Color.DarkGray});
        }
    }
}