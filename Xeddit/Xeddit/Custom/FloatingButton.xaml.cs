using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingButton : ContentView
    {
        public static readonly BindableProperty ButtonsProperty =
            BindableProperty.Create(nameof(Buttons), typeof(List<Button>), typeof(FloatingButton), new List<Button>());

        public static readonly BindableProperty IsOpenProperty =
            BindableProperty.Create(nameof(IsOpen), typeof(bool), typeof(FloatingButton), false, propertyChanged:
                (bindable, value, newValue) =>
                {
                    if (newValue is true && bindable is FloatingButton button) button.ShowButtons(); 
                });

        private bool m_open;
        private double m_spacing = 25;

        public FloatingButton()
        {
            InitializeComponent();
        }

        public bool IsOpen
        {
            get => (bool) GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public List<Button> Buttons
        {
            get => (List<Button>) GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        public event EventHandler Clicked;

        private void FloatingButtonClicked(object sender, EventArgs e)
        {
            ShowButtons();
            this.RelRotateTo(m_open ? -135 : 135, 250, Easing.CubicInOut);
            m_open = !m_open;

            Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void ShowButtons()
        {
            if (!(Parent is AbsoluteLayout parent)) return;
            var index = 1;
            foreach (var button in Buttons)
            {
                AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.None);
                AbsoluteLayout.SetLayoutBounds(button,
                    new Rectangle(Bounds.X, Bounds.Y + (Bounds.Height + m_spacing) * -index, AbsoluteLayout.AutoSize,
                        AbsoluteLayout.AutoSize));

                ToggleVisibility(button, parent);
                index++;
            }
        }

        private async void ToggleVisibility(Button button, AbsoluteLayout parent)
        {
            if (m_open)
            {
                await button.ScaleTo(0, 200, Easing.SinIn);
                button.IsVisible = false;
                parent.Children.Remove(button);
            }
            else
            {
                button.Scale = 0;
                button.IsVisible = true;
                parent.Children.Add(button);
                await button.ScaleTo(1, 200, Easing.SinIn);
            }
        }
    }
}