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
    public partial class home : ContentPage
    {
      
        public Command touch_command { get; }
        public home()
        {
            InitializeComponent();

            BindingContext = new CarsViewModel();
            touch_command = new Command(() => clickCommand());
        }

        async public void clickCommand()
        {
            await Navigation.PopAsync();
        }

        async private void OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskList());
        }
    }
}