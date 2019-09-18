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
        public MainPage(SubredditPage subredditPage)
        {
            InitializeComponent();

            Children.Add(new NavigationPage(subredditPage){Title = "asdasd"});
        }
    }
}