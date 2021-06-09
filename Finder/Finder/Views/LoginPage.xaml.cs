using Finder.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel vm;
        public LoginPage()
        {
            vm = new LoginViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            InitVMComponents();
            AnimationLogo();
#if DEBUG
            entry_Login.Text = "eve.holt@reqres.in";
            entry_Pass.Text = "cityslicka";
#endif
        }

        #region Methods
        private async void AnimationLogo()
        {
            while (!vm.IsBusy)
            {
                await img_heart.ScaleTo(0.99, 200, Easing.SinInOut);
                await img_heart.ScaleTo(1, 200, Easing.SinInOut);
                await img_heart.ScaleTo(0.99, 200, Easing.SinInOut);
                await img_heart.ScaleTo(1, 200, Easing.SinInOut);
                await Task.Delay(500);
            }
        }

        private void InitVMComponents()
        {
            vm.frmLogin = frm_Login;
            vm.imgHeart = img_heart;
            vm.DisplayErrorMessage += async (args) =>
            {
                await DisplayAlert("Błąd", args, "OK");
            };
        }
        #endregion
    }
}