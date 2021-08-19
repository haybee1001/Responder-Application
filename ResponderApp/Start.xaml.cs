using ResponderApp.Model;
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
    public partial class Start : ContentPage
    {

        public readonly IGoogleManager _googleManager;

        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        public Start()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            InitializeComponent();


            MessagingCenter.Subscribe<Page, string[]>(this, "googleAuth", (sender, values) => {
                username.Text = values[0];
                email.Text = values[2];
            });


            string data = email.Text.ToString();

            if(data == "ebash4cast@gmail.com" || data == "ebash4cast@googlemail.com")
            {
                DisplayAlert("It worked oo", "Yes", "Close");
            }

        }
    }
}