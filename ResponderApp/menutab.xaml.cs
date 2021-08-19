using ResponderApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menutab : TabbedPage
    {
        public menutab(string menu, Uri url, string email)
        {
            InitializeComponent();

           // BindingContext = this;

            var page = new home();

            string[] values = { menu, url.ToString(), email};

            MessagingCenter.Send<Page, string[]>(this, "googleAuth", values);

            MessagingCenter.Send<Page, string>(this, "Hi", "Bobo Dey here ooo");

           // Navigation.PushAsync(page);


           // Navigation.PopAsync();
        }
    }
}