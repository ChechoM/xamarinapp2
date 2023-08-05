using AppParqueadero.Services;
using AppParqueadero.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppParqueadero
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Startup.Initialize();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
