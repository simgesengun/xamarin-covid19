using Covid19.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {

        public MDPMaster()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("age"))
            {
                age.Text = Application.Current.Properties["age"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("username"))
            {
                username.Text = Application.Current.Properties["username"] as string;
            }
        }

        async void LogoutClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Logout", "Logout Clicked", "OK");
        }
    }
}