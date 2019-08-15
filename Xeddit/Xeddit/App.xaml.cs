﻿using LightInject;
using Xamarin.Forms;

namespace Xeddit
{
    public partial class App : Application
    {
        private ServiceContainer m_container;

        public App()
        {
            InitializeComponent();

            m_container = new ServiceContainer(new ContainerOptions() {EnablePropertyInjection = false});
            m_container.RegisterFrom<CompositionRoot>();

            MainPage = m_container.GetInstance<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}