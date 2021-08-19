﻿using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public readonly IGoogleManager _googleManager;

        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        public Page4()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            InitializeComponent();

            MessagingCenter.Subscribe<Page, string[]>(this, "googleAuth", (sender, values) => {
                username.Text = values[0];
                profilepic.Source = values[1];
                email.Text = values[2];
            });

        }
        async private void OnTapped(object sender, EventArgs e)
        {
        }

        private void CheckUserLoggedIn()
        {
            
        }

        public void logout_user(object sender, EventArgs e)
        {
            _googleManager.Logout();
            IsLogedIn = false;
            Navigation.PopAsync();
        }
    }
}