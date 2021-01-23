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

            WorldData.Add(new CountryData { Flag = "f_usa.png", Name = "USA", Cases = "277K", Recovered = "230K", Deaths = "3.895" });
            WorldData.Add(new CountryData { Flag = "f_china.png", Name = "China", Cases = "87K", Recovered = "82K", Deaths = "4.634" });
            WorldData.Add(new CountryData { Flag = "f_india.png", Name = "India", Cases = "18K", Recovered = "16K", Deaths = "165" });
            WorldData.Add(new CountryData { Flag = "f_germany.png", Name = "Germany", Cases = "24K", Recovered = "19K", Deaths = "1083" });
            WorldData.Add(new CountryData { Flag = "f_italy.png", Name = "Italy", Cases = "17K", Recovered = "15K", Deaths = "620" });
            WorldData.Add(new CountryData { Flag = "f_france.png", Name = "France", Cases = "19K", Recovered = "21K", Deaths = "589" });
            WorldData.Add(new CountryData { Flag = "f_uk.png", Name = "UK", Cases = "68K", Recovered = "40K", Deaths = "1325" });



        }
    }

    
}
