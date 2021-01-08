using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Curfew : ContentView
    {
        int age, selfAge;
        public Curfew() {
        
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("age"))
            {
                selfAge = (int)(Application.Current.Properties["age"]);
                yourAge.Text = "Your age: " + selfAge.ToString();
                calculate(selfAge);
            }
        }
    
        private void Age_Completed(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            if (text == "")
            {
                calculate(selfAge);
            }
            else
            {
                try
                {
                    age = Int32.Parse(text);
                }
                catch (FormatException ex)
                {
                    ((Entry)sender).Text = "Please enter a valid age";
                    return;
                }
                calculate(age);
            }

        }

        private void calculate(int age) {

            if (IsWeekend(DateTime.Now.DayOfWeek))
            {
                setBackground(false, false, false, false);
            }
            else
            {
                if (age < 20)
                {
                    setBackground(false, true, false, false);
                    return;
                }
                else if (age >= 65)
                {
                    setBackground(true, false, false, false);
                    return;
                }
                else setBackground(true, true, true, true);
            }
        }

        private void setBackground(bool one, bool two, bool three, bool four)
        {

            morning.BackgroundColor = boolToColor(one);
            afternoon.BackgroundColor = boolToColor(two);
            evening.BackgroundColor = boolToColor(three);
            night.BackgroundColor = boolToColor(four);
            
        }
        private Color boolToColor(bool isValid) {
            if (isValid) return Color.LightGreen;
            else return Color.IndianRed;
        }

        private bool IsWeekend(DayOfWeek day)
        {
            if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
            {
                return true;
            }


            return false;
        }
    }
}