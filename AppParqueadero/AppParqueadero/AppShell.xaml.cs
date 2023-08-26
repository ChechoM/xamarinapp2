using AppParqueadero.ViewModels;
using AppParqueadero.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppParqueadero
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ClientDetallePage), typeof(ClientDetallePage));
            Routing.RegisterRoute(nameof(MapasPage), typeof(MapasPage));
            Routing.RegisterRoute(nameof(CalificacionesPage), typeof(CalificacionesPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}
