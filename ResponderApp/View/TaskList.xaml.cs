using Newtonsoft.Json;
using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string useremail;

        public ObservableCollection<api> Items { get; set; }

        public TaskList()
        {
            InitializeComponent();


            MessagingCenter.Subscribe<Page, string[]>(this, "googleAuth", (sender, values) =>
            {
                useremail = values[2];
                if (useremail.Equals("ebash4cast@googlemail.com"))
                { loadDataFromDb("A"); }
                else { loadDataFromDb("B"); }

            });

            BindingContext = new homeViewModel();
        }

        public async void loadDataFromDb(string grp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://denceapp.somee.com/api/Incidence/GetAllAssignedTaskByGroup/");
                var responseTask = client.GetAsync(grp);

                responseTask.Wait();

                var res = responseTask.Result;
                if (res.IsSuccessStatusCode)
                {
                    string readTask = await res.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ObservableCollection<api>>(readTask);
                    Items = new ObservableCollection<api>(data);

                    generalList.ItemsSource = Items;

                }
            }
        }



        private void searchbar_textchanged(object sender, TextChangedEventArgs e)
        {
            var container = BindingContext as homeViewModel.api;

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                generalList.ItemsSource = Items;
            else
                generalList.ItemsSource = Items.Where(i => i.AssignedBy.ToLower().Contains(e.NewTextValue.ToLower()));

            generalList.EndRefresh();
        }

        async private void CarsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselectedItem = e.Item as api;
            
            await Navigation.PushAsync(new TaskDetails(myselectedItem.incidence_id, myselectedItem.lat_y, myselectedItem.Long_x, myselectedItem.ReporterName, myselectedItem.incidence_id));

            ((ListView)sender).SelectedItem = null;
        }

        async private void back_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}