using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DIPS.Xamarin.UI.Extensions;
using Xeddit.Resources.Fonts;

namespace Xeddit.Views.Subreddit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubredditBackView : ContentView
    {
        public SubredditBackView()
        {
            InitializeComponent();

        }

        private void MenuButtonTapped(object sender, EventArgs e)
        {
            if (!(sender is Label label)) return;

            var backDrop = label.GetParentOfType<BackDrop>();
            if (backDrop != null)
            {
                BackDrop.SetShowBackDrop(backDrop, !BackDrop.GetShowBackDrop(backDrop));
                RunAnimation(label, !BackDrop.GetShowBackDrop(backDrop));
            }

        }

        private static void RunAnimation(Label label, bool backDropShowing)
        {
            var parent = new Animation();
            var firstRotation = new Animation(rotation => label.Rotation = rotation, 0, 90, Easing.CubicOut, () => label.Text = backDropShowing ? FontIcons.Bars : FontIcons.Times)
            {
                { 0, 1, new Animation(opacity => label.Opacity = opacity, 1, 0, Easing.CubicInOut) }
            };
            var secondRotation = new Animation(rotation => label.Rotation = rotation, 90, 180, Easing.CubicOut, () => { })
            {
                { 0, 1, new Animation(opacity => label.Opacity = opacity, 0, 1, Easing.CubicOut) }
            };
            parent.Add(0, .5, firstRotation);
            parent.Add(.5, 1, secondRotation);
            parent.Commit(label, "FlipAnimation");
        }

        private void ListItemTapped(object sender, EventArgs e)
        {
            var backDrop = (sender as VisualElement)?.GetParentOfType<BackDrop>();
            if (backDrop == null) return;
            BackDrop.SetShowBackDrop(backDrop, !BackDrop.GetShowBackDrop(backDrop));
        }
    }
}