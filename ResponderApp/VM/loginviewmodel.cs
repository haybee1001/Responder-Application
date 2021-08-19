using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ResponderApp.VM
{
    //public class loginviewmodel
    //{
    //    private readonly IGoogleManager _googleManager;
    //    GoogleUser GoogleUser = new GoogleUser();
    //    public bool IsLogedIn { get; set; }

    //    public loginviewmodel()
    //    {
    //        _googleManager = DependencyService.Get<IGoogleManager>();
    //        CheckUserLoggedIn();
    //    }


    //    async private void OnTapped(object sender, EventArgs e)
    //    {
    //        _googleManager.Login(OnLoginComplete);
    //    }

    //    private void CheckUserLoggedIn()
    //    {
    //        _googleManager.Login(OnLoginComplete);
    //    }

    //    private void btnLogin_Clicked(object sender, EventArgs e)
    //    {
    //        _googleManager.Login(OnLoginComplete);
    //    }
    //    private void OnLoginComplete(GoogleUser googleUser, string message)
    //    {
    //        if (googleUser != null)
    //        {
    //            GoogleUser = googleUser;
    //            MessagingCenter.Send<object, string>(this, "xxx", googleUser.Email);
    //            IsLogedIn = true;
    //        }
    //        else
    //        {
    //            // Error Message on Login 
    //        }
    //    }
    //    private void GoogleLogout()
    //    {
    //        _googleManager.Logout();
    //        IsLogedIn = false;
    //    }
    //}
}
