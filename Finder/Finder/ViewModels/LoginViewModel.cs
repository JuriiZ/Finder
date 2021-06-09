using Finder.Models;
using Finder.Services;
using Finder.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Finder.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        #region Commands
        public Command LoginCommand { get; }
        public Action<string> DisplayErrorMessage;
        #endregion

        #region Properties
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public Frame frmLogin { get; set; }
        public Image imgHeart { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        #region Methods
        private async void OnLoginClicked()
        {
            IsBusy = true;
            await Task.WhenAll(new List<Task>() 
                { 
                    Helper.AnimationView(frmLogin, 100), 
                    Task.Delay(1000)
                });

            var response = await ServicesAsync.LoginRequestAsync(HttpInstance.client, Email, Password);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                HttpInstance.InitializeClient();
                HttpInstance.ClearHttpClientToken();
                HttpInstance.AssingToken(token);
                App.Current.MainPage = new NavigationPage(new MainPage());
            }else
            {
                DisplayErrorMessage("Nie udało się zalogować. Sprawdź wpisany login oraz hasło");
            }
            IsBusy = false;
        }       
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
