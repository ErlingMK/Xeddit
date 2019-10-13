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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            InitialsView.Name = Entry.Text;
        }
    }
}