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
    public partial class Siginin : ContentPage
    {
        public Siginin()
        {
            InitializeComponent();

           
        }

        async private void isClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Object, string>(this, "finish", "Hello Dear");

            await Navigation.PushAsync(new index());
        }
    }
}