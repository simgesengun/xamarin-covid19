using Covid19.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Covid19.Models
{
    class WorldViewModel : BindableObject
    {

        public static ObservableCollection<CountryData> WorldData { get; set; }


        public WorldViewModel()
        {
            WorldData = new ObservableCollection<CountryData>();

            WorldData.Add(new CountryData {Flag="f_usa.png", Name = "USA", Cases = 1234, Recovered=1234, Deaths=23 });
            WorldData.Add(new CountryData { Flag = "f_china.png", Name = "China", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_india.png", Name = "India", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_germany.png", Name = "Germany", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_italy.png", Name = "Italy", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_france.png", Name = "France", Cases = 1234, Recovered = 1234, Deaths = 23 });
            WorldData.Add(new CountryData { Flag = "f_uk.png", Name = "UK", Cases = 1234, Recovered = 1234, Deaths = 23 });


        }
    }

    
}
