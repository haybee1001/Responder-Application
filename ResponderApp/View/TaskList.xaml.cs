using Newtonsoft.Json;
using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ResponderApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskList : ContentPage
    {
        public List<api> Items { get; set; }

        public TaskList()
        {
            InitializeComponent();
            BindingContext = new homeViewModel();
        }

        private void searchbar_textchanged(object sender, TextChangedEventArgs e)
        {
            var container = BindingContext as homeViewModel;

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CarsListView.ItemsSource = container.Items;
            else
                CarsListView.ItemsSource = container.Items.Where(i => i.AssignedBy.ToLower().Contains(e.NewTextValue.ToLower()));

            CarsListView.EndRefresh();
        }

        async private void CarsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselectedItem = e.Item as homeViewModel.api;

            await Navigation.PushAsync( new TaskDetails(myselectedItem.incidence_id));

            ((ListView)sender).SelectedItem = null;
       
        }


        //public async Task<List<api>> CarsViewModelss()
        //{
        //    string Baseurl = "https://denceapp.somee.com/";

        //    Items = new List<api>();

        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage Res = await client.GetAsync("api/Incidence/GetAllAssignedTaskByGroup/A");

        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var dataResponse = Res.Content.ReadAsStringAsync().Result;

        //            Items = JsonConvert.DeserializeObject<List<api>>(dataResponse);
        //        }
        //    }

        //    return Items;
        //}

        async private void back_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}