using System;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Essentials;

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

    internal interface IBrowser
    {
        Task GetAsync(Uri uri);
    }
}