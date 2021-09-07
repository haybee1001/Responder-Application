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
    public partial class Startwork : ContentPage
    {
        public Startwork()
        {
            InitializeComponent();
        }

        async private void OnTapped(object sender, EventArgs e)
        {
            //await CrossMedia.Current.Initialize();
        }

     }
}