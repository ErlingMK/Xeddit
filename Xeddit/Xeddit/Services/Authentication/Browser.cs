using System;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xeddit.Services.Authentication.Abstractions;

namespace Xeddit.Services.Authentication
{
    public class Browser : IBrowser
    {
        public async Task GetAsync(Uri uri)
        {
            await Xamarin.Essentials.Browser.OpenAsync(uri, new BrowserLaunchOptions()
            {
                LaunchMode = BrowserLaunchMode.External,
                PreferredToolbarColor = Color.AliceBlue,
                TitleMode = BrowserTitleMode.Show
            });
        }
    }
}