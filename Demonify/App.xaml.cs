using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demonify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (App.Current.Properties.ContainsKey("Player")) MainPage = new NavigationPage(new Pages.PrimaryPage());
            else MainPage = new Pages.Creation();
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

        //TODO - Save player estate on app killed
    }
}
