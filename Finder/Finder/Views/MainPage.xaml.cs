using Finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            vm = new MainPageViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            InitVMComponents();
            OpacityElements();
        }

        #region Properties
        public MainPageViewModel vm;
        #endregion

        #region Methods
        private void InitVMComponents()
        {
            vm.swipeCardView = SwipeCard;
            vm.frmReject = frm_Reject;
            vm.frmLike = frm_Like;
            vm.svgSettings = svg_Settings;
            vm.svgMessages = svg_Mess;
        }

        private async void OpacityElements()
        {
            stkAllDialog.Opacity = 0;
            stkAll.Opacity = 1;
            stkAll.IsVisible = true;
            stkAllDialog.IsVisible = true;
            await Task.Delay(500);

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    await Task.Run(() => stkAllDialog.FadeTo(0, 500));
                    await Task.Run(() => stkAllDialog.FadeTo(1, 1200));
                    await Task.Run(() => stkAllDialog.FadeTo(0, 1200, Easing.SinIn));
                    break;

                case Device.Android:
                    await Task.Run(() => stkAllDialog.FadeTo(1, 1200));
                    await Task.Run(() => stkAllDialog.FadeTo(0, 1200, Easing.SinIn));
                    break;
            }

            await Task.Run(() => stkAll.FadeTo(0, 300));
            stkAll.IsVisible = false;
            stkAllDialog.IsVisible = false;
        }
        #endregion
    }
}