using Newtonsoft.Json;
using ResponderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;

namespace ResponderApp
{
    public class homeViewModel
    {


        public event PropertyChangedEventHandler PropertyChanged;
        public string assignedCount;
        string uname;
        string usergroup;

        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        //public ObservableCollection<Car> Items { get; set; }
        public ObservableCollection<api> Items { get; set; }

        public homeViewModel()
        {
            MessagingCenter.Subscribe<Page, string>(this, "xxx", (sender, values) =>
            {
                uname = values;
            });

            load();
        }

        //public ObservableCollection<api> Items { get; set; }
        public async void load()
        {
            // MessagingCenter.Unsubscribe<Page, string>(this, "usergroup");

            if (uname == "ebash4cast@gmail.com")
            {
                usergroup = "A";
            }
            else
            {
                usergroup = "B";
            }

            List<api> trackData = new List<api>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://denceapp.somee.com/api/Incidence/GetAllAssignedTaskByGroup/");
                var responseTask = client.GetAsync(usergroup);

                responseTask.Wait();

                var res = responseTask.Result;
                if (res.IsSuccessStatusCode)
                {
                    string readTask = await res.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ObservableCollection<api>>(readTask);
                    assignedCount = data.Count().ToString();
                    Items = new ObservableCollection<api>(data);
                   
                }

                MessagingCenter.Send<object, string>(this, "assignedPassed", assignedCount);

            }
        }

        //public CarsViewModel()
        //{

            //    Here you can have your data form db or something else,
            //     some data that you already have to put in the list
            //    Items = new ObservableCollection<Car>() {
            //        new Car()
            //        {
            //            CarID = 1,
            //            Make = "Power Outage",
            //            YearOfModel = 2021
            //        },
            //          new Car()
            //        {
            //            CarID = 2,
            //            Make = "Fault",
            //            YearOfModel = 2012
            //        },
            //           new Car()
            //        {
            //            CarID = 2,
            //            Make = "Whistle",
            //            YearOfModel = 2100
            //        },
            //            new Car()
            //        {
            //            CarID = 2,
            //            Make = "Fault",
            //            YearOfModel = 2012
            //        },
            //             new Car()
            //        {
            //            CarID = 2,
            //            Make = "Fault",
            //            YearOfModel = 2012
            //        },
            //                new Car()
            //        {
            //            CarID = 2,
            //            Make = "Complain",
            //            YearOfModel = 2012
            //        },

            //          new Car()
            //        {
            //            CarID = 2,
            //            Make = "Fault",
            //            YearOfModel = 2007
            //        },

            //         new Car()
            //        {
            //            CarID = 2,
            //            Make = "Complain",
            //            YearOfModel = 2012
            //        },

            //         new Car()
            //        {
            //            CarID = 2,
            //            Make = "Complain",
            //            YearOfModel = 221
            //        },

            //        new Car()
            //        {
            //            CarID = 2,
            //            Make = "Whistle",
            //            YearOfModel = 2012
            //        }


            //    };

            //}

            //Messaging 

        //Messaging Other Values

        public class Car
        {
            public int CarID { get; set; }
            public string Make { get; set; }
            public int YearOfModel { get; set; }
        }

        public class api
        {
            public string TaskId { get; set; }
            public string Status { get; set; }
            public string AssignedBy { get; set; }
            public string Descrtiption { get; set; }
            public string ReporterName { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string DateReported { get; set; }
            public string Long_x { get; set; }
            public string lat_y { get; set; }
            public string incidence_id { get; set; }
        }
    }
}
