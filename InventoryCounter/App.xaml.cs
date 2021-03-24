﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InventoryCounter.Views;

namespace InventoryCounter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginPage());
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
