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
    public partial class CarsPage : ContentPage
    {
        public CarsPage()
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
                CarsListView.ItemsSource = container.Items.Where(i =>  i.Make.ToLower().Contains(e.NewTextValue.ToLower()) );

            CarsListView.EndRefresh();
        }
    }
}