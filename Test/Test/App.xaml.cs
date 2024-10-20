using System;
using Test.Models;
using Test.Services;
using Test.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //DependencyService.Register<FileStorage>();
            //DependencyService.Register<ProviderDataStore<Item>>();
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
