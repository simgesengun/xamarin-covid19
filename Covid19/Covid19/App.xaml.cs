using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental" });
            InitializeComponent();
            Sharpnado.Tabs.Initializer.Initialize(loggerEnable: false, debugLogEnable: false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            var nav = new NavigationPage(new LoginPage());
            nav.BarBackgroundColor = Color.White;
            nav.BackgroundColor = Color.White;
            MainPage = nav;
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
