using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Covid19.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string popupUsers;
        public LoginPage()
        {
            InitializeComponent();
            // uncomment below line to see existing users
            getUsers();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());

        }
        async void getUsers()
        {
            List<User> users = await App.Database.GetUsersAsync();
            foreach (User user in users)
            {
                popupUsers += "ID = " + user.Id + "\nUsername = " + user.username + "\nEmail = " + user.email + "\nPassword = " + user.password + "\n";
            }
            await DisplayAlert("Users", popupUsers, "OK");

        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            bool exists = await App.Database.userExistsAsync(nameEntry.Text, passwordEntry.Text);
            if (exists)
            {
                User user = await App.Database.GetUserAsync(nameEntry.Text, passwordEntry.Text);
                passwordEntry.Text = string.Empty;
                nameEntry.Text = string.Empty;
                await Navigation.PushModalAsync(new MDP());
            }
            else
            {
                if (await DisplayAlert("Invalid email, username or password", "Would you like to register?", "Sign Up", "Try Again"))
                {
                    passwordEntry.Text = string.Empty;
                    nameEntry.Text = string.Empty;
                    await Navigation.PushAsync(new RegisterPage());
                }
            }

        }

        void passwordEye(object sender, EventArgs e)
        {
            if (passwordEntry.IsPassword)
            {
                passwordImg.Source = "password.png";
                passwordEntry.IsPassword = false;
            }
            else
            {
                passwordImg.Source = "password_hide.png";
                passwordEntry.IsPassword = true;
            }
        }
        void nameCheck(object sender, EventArgs e)
        {
            if (IsValid(nameEntry.Text))
                emailImg.Source = "check_filled.png";
            else
                emailImg.Source = "check.png";
        }
        public bool IsValid(string name)
        {
            if (Regex.IsMatch(name, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") ||
                Regex.IsMatch(name, @"^(?!.*[-_]{2,})(?=^[^-_].*[^-_]$)[\w\s-]{3,9}$"))
                return true;
            else return false;
        }
    }
}