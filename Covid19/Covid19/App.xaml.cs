using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Covid19.Data;

[assembly: ExportFont("Poppins-Bold.ttf", Alias = "PoppinsBold")]
[assembly: ExportFont("Poppins-Italic.ttf", Alias = "PoppinsItalic")]
[assembly: ExportFont("Poppins-Regular.ttf", Alias = "Poppins")]
namespace Covid19
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental", "Brush_Experimental" });
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
