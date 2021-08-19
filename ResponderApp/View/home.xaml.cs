﻿using Newtonsoft.Json;
using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponderApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
        public string useremail;
        public Command touch_command { get; }

        public string assignedCount;
        string uname;
        string usergroup;

        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        //public ObservableCollection<Car> Items { get; set; }
        public ObservableCollection<api> Items { get; set; }

        public home()
        {

            InitializeComponent();

            MessagingCenter.Subscribe<Page, string[]>(this, "googleAuth", (sender, values) => {
                lblUser.Text = values[0];
                profilePhoto.Source = values[1];
                useremail = values[2];
                if(useremail.Equals("ebash4cast@googlemail.com"))
                { loadDataFromDb("A"); } else { loadDataFromDb("B"); }
                
            });


            //MessagingCenter.Subscribe<Page, string>(this, "Hi", (sender, values) =>
            //{
            //    lblAssigned.Text = values;

            //    if(values == "Bobo Dey here oo")
            //    {
            //        loadDataFromDb();
            //    }
            //    else
            //    {
            //        DisplayAlert("Hello", "Conflict of Interest", "Close");
            //    }

            //});

            string data = lblAssigned.Text;



            //lblAssigned.Text = data;

            //MessagingCenter.Subscribe<Page, string>(this, "xxx", (sender, values) =>
            //{
            //    uname = values;
            //});


            //Check for user email
            //string[] emailAddress = { "ea@enugudisco.com", "bc@enugudisco.com" };


            //loadDataFromDb();

            Console.WriteLine("The value is:" + uname);

            //BindingContext = new homeViewModel();

           // touch_command = new Command(() => clickCommand());

           // MessagingCenter.Subscribe<object, string>(this, "assignedPassed", (sender, values) => { lblAssigned.Text = values.ToString(); });

        }



        public async void loadDataFromDb(string grp)
        {

            List<api> trackData = new List<api>();
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
                    assignedCount = data.Count().ToString();
                    Items = new ObservableCollection<api>(data);

                    mylistview.ItemsSource = Items;
                   
                }

                lblAssigned.Text = assignedCount;
                //MessagingCenter.Send<object, string>(this, "assignedPassed", assignedCount);

            }
        }

        async public void clickCommand()
        {
            await Navigation.PopAsync();
        }

        async private void OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskList());
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            ///await Task.Delay(3000);

            BindingContext = new homeViewModel();

            listRefresher.IsRefreshing = false;
        }

       
    }
}