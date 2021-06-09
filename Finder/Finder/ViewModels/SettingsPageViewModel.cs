using Finder.Models;
using Finder.Services;
using Finder.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Finder.ViewModels
{
    public class SettingsPageViewModel: INotifyPropertyChanged
    {
        public SettingsPageViewModel()
        {
            Task.Run(async () => await InitUserByIdAsync());
            OnTapLogoutCommand = new Command(OnTapLogout);
            OnTapBackCommand = new Command(OnTapBack);
        }

        #region Commands
        public ICommand OnTapLogoutCommand { get; }
        public ICommand OnTapBackCommand { get; }
        #endregion

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Random rnd = new Random();
        private UserModel _user = new UserModel();
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        #endregion

        #region Methods
        private async Task InitUserByIdAsync()
        {
            int id = rnd.Next(1, 13);
            var httpResponse = await ServicesAsync.GetUsersByIdAsync(HttpInstance.client, id);

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseModel = await DataHandler.ReadUserByIdResponse(httpResponse);
                User = responseModel.data;
            }
        }

        private void OnTapLogout()
        {
            App.Current.MainPage = new LoginPage();
        }

        private async void OnTapBack()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync(true);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
