using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponderApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        public login()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            InitializeComponent();

           
        }

        async private void OnTapped(object sender, EventArgs e)
        {

            
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            
            CheckUserLoggedIn();

         
        }

        private void CheckUserLoggedIn()
        {
            _googleManager.Login(OnLoginComplete);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
           // _googleManager.Login(OnLoginComplete);

            DisplayAlert("Info","Data is displayed","Ok");
        }
        async private void OnLoginComplete(GoogleUser googleUser, string message)
        {
            GoogleUser = googleUser;

            var page = new home();

            if (googleUser != null)
            {
                GoogleUser = googleUser;
                string[] values = { googleUser.Name, googleUser.Picture.ToString(), googleUser.Email };

                MessagingCenter.Send<Page, string[]>(this, "googleAuth1", values);

                await Navigation.PushAsync(new menutab(googleUser.Name, googleUser.Picture, googleUser.Email));

                IsLogedIn = true;
                activity.IsEnabled = false;
                activity.IsRunning = false;
                activity.IsVisible = false;

            }
            else
            {
                DisplayAlert("Message", message, "Ok");
            }
        }
        private void GoogleLogout()
        {
            _googleManager.Logout();
            IsLogedIn = false;
        }
        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            _googleManager.Logout();

        }

        private void googleButtonTapped(object sender, EventArgs e)
        {
        }
    }
}