using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Views.Front.ViewModel;

namespace Xeddit.Views.Front
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditPage : ContentPage
    {
        public SubredditPage(IContextViewModel contextViewModel)
        {
            InitializeComponent();

            BindingContext = contextViewModel;
        }
    }
}