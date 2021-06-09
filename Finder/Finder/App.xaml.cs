using Finder.Services;
using Finder.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finder
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            HttpInstance.InitializeClient();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
