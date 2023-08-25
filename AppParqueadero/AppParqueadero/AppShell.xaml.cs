﻿using AppParqueadero.ViewModels;
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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
