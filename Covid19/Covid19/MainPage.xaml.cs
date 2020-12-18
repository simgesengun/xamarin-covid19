using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Covid19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TabHost.SelectedIndex = 0;
        }
    }
}
