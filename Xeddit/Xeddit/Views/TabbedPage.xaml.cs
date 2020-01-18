using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Views.Front;

namespace Xeddit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage : Xamarin.Forms.TabbedPage
    {
        public TabbedPage(SubredditPage subredditPage)
        {
            InitializeComponent();

            Children.Add(new NavigationPage(subredditPage){Title = "Posts", BarBackgroundColor = Color.DarkGray});
        }
    }
}