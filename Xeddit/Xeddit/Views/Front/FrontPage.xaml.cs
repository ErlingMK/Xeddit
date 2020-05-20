using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.Custom;
using Xeddit.DataViewModels;
using Xeddit.Resources.Fonts;
using Xeddit.Views.Comments;
using Xeddit.Views.Comments.ViewModel;
using Xeddit.Views.Front.ViewModel;
using Xeddit.Views.Subreddit;
using Xeddit.Views.Subreddit.ViewModel;

namespace Xeddit.Views.Front
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrontPage : ContentPage
    {
        private readonly IFrontViewModel m_frontViewModel;
        private SubredditBackView m_subredditBackView;
        private SubredditFrontView m_subredditFrontView;

        public FrontPage(IFrontViewModel frontViewModel)
        {
            BindingContext = m_frontViewModel = frontViewModel;
            m_frontViewModel.PropertyChanged += FrontViewModel_OnPropertyChanged;
            m_subredditBackView = new SubredditBackView {BindingContext = m_frontViewModel.CurrentListing};
            m_subredditFrontView = new SubredditFrontView {BindingContext = m_frontViewModel.CurrentListing};

            InitializeComponent();
        }

        private async void FrontViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(sender is IFrontViewModel viewModel) || e.PropertyName != nameof(viewModel.CurrentListing)) return;

            switch (viewModel.CurrentListing)
            {
                case ISubredditPageViewModel _:
                    await CommentsBackDrop.FadeTo(0, 150);
                    await SubredditBackDrop.FrontLayerContent.FadeTo(1, 150);
                    BackDropContainer.LowerChild(CommentsBackDrop);
                    SubredditBackDrop.FrontLayerContent.InputTransparent = false;
                    break;
                case ICommentPageViewModel _:
                    await SubredditBackDrop.FrontLayerContent.FadeTo(0, 150);
                    await Task.WhenAll(CommentsBackDrop.FadeTo(1, 100), MoveFrame());
                    BackDropContainer.LowerChild(SubredditBackDrop);
                    break;
            }
        }

        private async Task MoveFrame()
        {
            var last = BackDropContainer.Children.Last();
            var frontLayerContent = CommentsBackDrop.FrontLayerContent as CommentsFrontView;
            await last.LayoutTo(
                new Rectangle(new Point(0, frontLayerContent.Bounds.Y + CommentsBackDrop.FrontLayerOffset),
                    new Size(frontLayerContent.Bounds.Width, last.Bounds.Height)), 150, Easing.CubicInOut);
            frontLayerContent.LinkTitleFrame = last;
        }

        protected override bool OnBackButtonPressed()
        {
            if (!(m_frontViewModel.CurrentListing is ICommentPageViewModel)) return true;
            (CommentsBackDrop.FrontLayerContent as CommentsFrontView).LinkTitleFrame = null;
            m_frontViewModel.CurrentListing = m_frontViewModel.SubredditPageViewModel;
            return true;
        }

        private void FloatingButtonClicked(object sender, EventArgs e)
        {
            if (!(sender is FloatingButton button)) return;
            BackDrop.SetShowBackDrop(SubredditBackDrop, !BackDrop.GetShowBackDrop(SubredditBackDrop));
            //RunAnimation(button, !BackDrop.GetShowBackDrop(SubredditBackDrop));
        }

        private static void RunAnimation(Button button, bool backDropShowing)
        {
            var parent = new Animation();
            var firstRotation = new Animation(rotation => button.Rotation = rotation, 0, 90, Easing.CubicOut,
                () => button.Text = backDropShowing ? FontIcons.Bars : FontIcons.Times)
            {
                {0, 1, new Animation(opacity => button.Opacity = opacity, .5, 0, Easing.CubicInOut)}
            };
            var secondRotation =
                new Animation(rotation => button.Rotation = rotation, 90, 180, Easing.CubicOut, () => { })
                {
                    {0, 1, new Animation(opacity => button.Opacity = opacity, 0, .5, Easing.CubicOut)}
                };
            parent.Add(0, .5, firstRotation);
            parent.Add(.5, 1, secondRotation);
            parent.Commit(button, "FlipAnimation");
        }
    }
}