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
    public partial class TaskList : ContentPage
    {
        public TaskList()
        {
            InitializeComponent();
            BindingContext = new CarsViewModel();
        }

        private void searchbar_textchanged(object sender, TextChangedEventArgs e)
        {
            var container = BindingContext as CarsViewModel;
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CarsListView.ItemsSource = container.Items;
            else
                CarsListView.ItemsSource = container.Items.Where(i => i.Make.ToLower().Contains(e.NewTextValue.ToLower()));

            CarsListView.EndRefresh();
        }

        async private void CarsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselectedItem = e.Item as CarsViewModel.Car;

            
          
            await Navigation.PushAsync( new Page1(myselectedItem.Make));

            ((ListView)sender).SelectedItem = null;
       
        }

        async private void back_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}