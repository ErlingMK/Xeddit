using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Views.Comments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsFrontView : ContentView
    {
        public static readonly BindableProperty LinkTitleFrameProperty = BindableProperty.Create(
            nameof(LinkTitleFrame),
            typeof(View),
            typeof(CommentsFrontView));

        public CommentsFrontView()
        {
            InitializeComponent();
        }

        public View LinkTitleFrame
        {
            get => (View)GetValue(LinkTitleFrameProperty);
            set => SetValue(LinkTitleFrameProperty, value);
        }
    }
}