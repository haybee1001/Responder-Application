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

            string[] values = { menu, url.ToString(), email};

            MessagingCenter.Send<Page, string[]>(this, "googleAuth", values);

            MessagingCenter.Send<Page, string>(this, "Hi", "A");

                      

        }
    }
}