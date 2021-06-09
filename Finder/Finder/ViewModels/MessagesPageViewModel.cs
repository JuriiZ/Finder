using Finder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Finder.ViewModels
{
    public class MessagesPageViewModel: INotifyPropertyChanged
    {
        public MessagesPageViewModel(List<UserModel> lst)
        {
            Matches = new ObservableCollection<UserModel>(lst);
            OnTapBackCommand = new Command(OnTapBack);
        }

        #region Commands
        public ICommand OnTapBackCommand { get; }
        #endregion

        #region Properties
        private ObservableCollection<UserModel> _matches = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Matches
        {
            get => _matches;
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        #region Methods
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async void OnTapBack()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync(true);
        }
        #endregion
    }
}
