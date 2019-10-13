using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostListObject : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title), 
            typeof(string), 
            typeof(PostListObject), 
            string.Empty); 

        public static readonly BindableProperty AuthorProperty = BindableProperty.Create(
            nameof(Author), 
            typeof(string), 
            typeof(PostListObject), 
            string.Empty);

        public static readonly BindableProperty ScoreProperty = BindableProperty.Create(
            nameof(Score),
            typeof(int),
            typeof(PostListObject),
            0);

        public PostListObject()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Author
        {
            get => (string) GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }

        public int Score
        {
            get => (int) GetValue(ScoreProperty);
            set => SetValue(ScoreProperty, value);
        }

    }
}