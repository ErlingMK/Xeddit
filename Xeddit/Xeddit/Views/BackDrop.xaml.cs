using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackDrop : ContentView
    {
        public static readonly BindableProperty ShowBackDropProperty = BindableProperty.CreateAttached(
            "ShowBackDrop",
            typeof(bool),
            typeof(BackDrop),
            false,
            propertyChanged: ShowBackDropChanged);

        public static readonly BindableProperty BackLayerContentProperty = BindableProperty.Create(
            nameof(BackLayerContent),
            typeof(View),
            typeof(BackDrop));

        public static readonly BindableProperty FrontLayerContentProperty = BindableProperty.Create(
            nameof(FrontLayerContent),
            typeof(View),
            typeof(BackDrop));

        public static readonly BindableProperty FrontLayerOffsetProperty = BindableProperty.Create(
            nameof(FrontLayerOffset),
            typeof(int),
            typeof(BackDrop));

        public static readonly BindableProperty HeaderContentProperty =
            BindableProperty.Create(nameof(HeaderContent), typeof(View), typeof(BackDrop));

        public BackDrop()
        {
            InitializeComponent();
        }

        public int FrontLayerOffset
        {
            get => (int) GetValue(FrontLayerOffsetProperty);
            set => SetValue(FrontLayerOffsetProperty, value);
        }

        public View FrontLayerContent
        {
            get => (View) GetValue(FrontLayerContentProperty);
            set => SetValue(FrontLayerContentProperty, value);
        }

        public View BackLayerContent
        {
            get => (View) GetValue(BackLayerContentProperty);
            set => SetValue(BackLayerContentProperty, value);
        }

        public View HeaderContent
        {
            get => (View) GetValue(HeaderContentProperty);
            set => SetValue(HeaderContentProperty, value);
        }

        private static void ShowBackDropChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is BackDrop backDrop)
            {
                if (newvalue is true) backDrop.ShowBackLayer();
                else backDrop.HideBackLayer();
            }
        }

        private async void ShowBackLayer()
        {
            await Task.WhenAll(
                FrontLayer.TranslateTo(
                    0,
                    BackLayer.Height <= FrontLayerOffset
                        ? FrontLayerOffset
                        : BackLayer.Height - (HeaderContent?.Height ?? 30),
                    150,
                    Easing.CubicInOut),
                Scrim.FadeTo(1, 150, Easing.CubicInOut));

            Scrim.InputTransparent = false;
        }

        private async void HideBackLayer()
        {
            await Task.WhenAll(
                FrontLayer.TranslateTo(0, FrontLayerOffset, 150, Easing.CubicInOut),
                Scrim.FadeTo(0, 150, Easing.CubicInOut));

            Scrim.InputTransparent = true;
        }

        public static bool GetShowBackDrop(BindableObject view)
        {
            return (bool) view.GetValue(ShowBackDropProperty);
        }

        public static void SetShowBackDrop(BindableObject view, bool value)
        {
            view.SetValue(ShowBackDropProperty, value);
        }

        private void ScrimTapped(object sender, EventArgs e)
        {
            if (GetShowBackDrop(this)) HideBackLayer();
            else ShowBackLayer();
        }
    }
}