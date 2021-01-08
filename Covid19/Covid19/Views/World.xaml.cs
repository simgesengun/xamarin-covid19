using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Covid19.Models;
using System.Collections.ObjectModel;
using Covid19.Data;

namespace Covid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class World : ContentView
    {
        public ObservableCollection<CountryData> WorldData { get; set; }

        public World()
        {
            InitializeComponent();
            WorldData = new ObservableCollection<CountryData>();
            lvWorldData.ItemsSource = WorldData;
            WorldData.Add(new CountryData { Flag = "f_usa.png", Name = "USA", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_china.png", Name = "China", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_india.png", Name = "India", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_germany.png", Name = "Germany", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_italy.png", Name = "Italy", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_france.png", Name = "France", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_uk.png", Name = "UK", Cases = 1234, Recovered = 1234, Deaths = 23 });

        }
    }
}