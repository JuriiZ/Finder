using Finder.Models;
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
    public partial class MessagesPage : ContentPage
    {
        public MessagesPage(List<UserModel> lst)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new MessagesPageViewModel(lst);
            InitializeComponent();
        }
    }
}