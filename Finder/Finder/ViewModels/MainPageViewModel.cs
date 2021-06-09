using FFImageLoading.Svg.Forms;
using Finder.Models;
using Finder.Services;
using Finder.Views;
using MLToolkit.Forms.SwipeCardView;
using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Finder.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            Task.Run(async () => await InitUserListAsync());
            OnTapRejectCommand = new Command(OnTapRejectAsync);
            OnTapLikeCommand = new Command(OnTapLikeAsync);
            OnTapSettingsCommand = new Command(OnTapSettings);
            OnTapMessagesCommand = new Command(OnTapMessages);
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
        }

        #region Commands
        public ICommand SwipedCommand { get; }
        public ICommand OnTapRejectCommand { get; }
        public ICommand OnTapLikeCommand { get; }
        public ICommand OnTapSettingsCommand { get; }
        public ICommand OnTapMessagesCommand { get; }
        #endregion

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<UserModel> _users = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
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

        private List<UserModel> lst_Liked = new List<UserModel>();
        public SwipeCardView swipeCardView { get; set; }
        public Frame frmReject { get; set; }
        public Frame frmLike { get; set; }
        public SvgCachedImage svgSettings { get; set; }
        public SvgCachedImage svgMessages { get; set; }       
        #endregion

        #region Methods
        private async void OnTapSettings()
        {
            await Helper.AnimationSVG(svgSettings, 100);
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage(), true);
        }
        private async void OnTapMessages()
        {
            await Helper.AnimationSVG(svgMessages, 100);
            await App.Current.MainPage.Navigation.PushAsync(new MessagesPage(lst_Liked), true);
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async Task InitUserListAsync()
        {
            var httpResponse = await ServicesAsync.GetUsersListAsync(HttpInstance.client, 1);
            List<UserModel> userModels = new List<UserModel>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseModel = await DataHandler.ReadUsersResponse(httpResponse);
                userModels = responseModel.data;
            }

            httpResponse = await ServicesAsync.GetUsersListAsync(HttpInstance.client, 2);

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseModel = await DataHandler.ReadUsersResponse(httpResponse);
                userModels.AddRange(responseModel.data);
            }
            Users = new ObservableCollection<UserModel>(userModels);
        }

        private async void NewMessAnimation()
        {
            await svgMessages.ScaleTo(0.9, 200, Easing.SinInOut);
            await svgMessages.ScaleTo(1, 200, Easing.SinInOut);
            await svgMessages.ScaleTo(0.9, 200, Easing.SinInOut);
            await svgMessages.ScaleTo(1, 200, Easing.SinInOut);
        }

        private void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            var item = eventArgs.Item as UserModel;
            if (eventArgs.Direction == SwipeCardDirection.Right)
            {
                lst_Liked.Add(item);
                NewMessAnimation();
            }               
        }
        private async void OnTapRejectAsync()
        {
            IsBusy = true;
            await Task.WhenAll(new List<Task>()
                {
                    swipeCardView.InvokeSwipe(SwipeCardDirection.Left),
                    Helper.AnimationView(frmReject, 100)
                });
            IsBusy = false;
        }

        private async void OnTapLikeAsync()
        {
            IsBusy = true;
            await Task.WhenAll(new List<Task>()
                {
                    swipeCardView.InvokeSwipe(SwipeCardDirection.Right),
                    Helper.AnimationView(frmLike, 100)
                });
            IsBusy = false;
        }
        #endregion
    }
}
