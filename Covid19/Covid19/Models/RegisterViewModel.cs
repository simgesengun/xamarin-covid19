using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Covid19.Data;
using Xamarin.Forms;

namespace Covid19.Models
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string errorMessage, success;
        public RegisterViewModel()
        {
        }
        private bool _isValidUsername;
        private bool _isValidEmail;

        public bool isValidEmail
        {
            get { return _isValidEmail; }
            set
            {
                _isValidEmail = value;
                PropertyChanged(this, new PropertyChangedEventArgs("isValidEmail"));


            }
        }
        public bool isValidUsername
        {
            get { return _isValidUsername; }
            set
            {
                _isValidUsername = value;
                PropertyChanged(this, new PropertyChangedEventArgs("isValidUsername"));


            }
        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
                if (Regex.IsMatch(Username, @"^(?!.*[-_]{2,})(?=^[^-_].*[^-_]$)[\w\s-]{3,9}$"))
                {
                    isValidUsername = true;
                }
                else
                {
                    isValidUsername = false;
                }
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                if (Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    isValidEmail = true;
                }
                else
                {
                    isValidEmail = false;
                }
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string _dob;
        public string Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dob"));
            }
        }
        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        async private void Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Dob))
            {
                await App.Current.MainPage.DisplayAlert("Register", "Please fill all entries", "OK");
            }
            else
            {
                if (await Validate())
                {
                    await App.Database.SaveUserAsync(new User
                    {
                        username = Username,
                        email = Email,
                        password = Password,
                        dob = Dob,
                    });
                    success = "You have registered successfully!";
                    //uncomment below line to see more info about this user
                    success += "\nUsername: " + Username + "\nEmail: " + Email + "\nPassword: " + Password + "\nDOB: " + Dob;
                    await App.Current.MainPage.DisplayAlert("Register", success, "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Register", errorMessage, "OK");
                }
            }

        }
        public async Task<bool> validateUsername()
        {
            if (isValidUsername)
            {
                bool available = await App.Database.usernameAvailableAsync(Email);
                if (available)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Username is already registered";
                    return false;
                }
            }
            else
            {
                errorMessage = "Please enter a valid username";
                return false;
            }

        }
        public async Task<bool> validateEmail()
        {
            if (isValidEmail)
            {
                bool available = await App.Database.emailAvailableAsync(Email);
                if (available)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Email is already registered";
                    return false;
                }
            }
            else
            {
                errorMessage = "Please enter a valid email";
                return false;
            }

        }
        public bool validatePassword()
        {
            return true;
        }
        public bool validateDob()
        {
            if (Regex.IsMatch(Dob, @"\d{2}\/\d{2}\/\d{4}")) { return true; }
            else
            {
                errorMessage = "Please enter a valid date of birth";
                return false;
            }
        }
        public async Task<bool> Validate()
        {
            bool dob = validateDob();
            bool password = validatePassword();
            bool email = await validateEmail();
            bool username = await validateUsername();
            return email && password && dob && username;
        }

    }
}
