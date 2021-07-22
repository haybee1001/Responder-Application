using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ResponderApp
{
    public class CarsViewModel
    {
    
       
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Car> Items { get; set; }

        public void searchedPressed()
        { 
        
        }

        public CarsViewModel()
        {
           
            // Here you can have your data form db or something else,
            // some data that you already have to put in the list
            Items = new ObservableCollection<Car>() {
                new Car()
                {
                    CarID = 1,
                    Make = "Power Outage",
                    YearOfModel = 2021
                },
                  new Car()
                {
                    CarID = 2,
                    Make = "Fault",
                    YearOfModel = 2012
                },
                   new Car()
                {
                    CarID = 2,
                    Make = "Whistle",
                    YearOfModel = 2100
                },
                    new Car()
                {
                    CarID = 2,
                    Make = "Fault",
                    YearOfModel = 2012
                },
                     new Car()
                {
                    CarID = 2,
                    Make = "Fault",
                    YearOfModel = 2012
                },
                        new Car()
                {
                    CarID = 2,
                    Make = "Complain",
                    YearOfModel = 2012
                },

                  new Car()
                {
                    CarID = 2,
                    Make = "Fault",
                    YearOfModel = 2007
                },

                 new Car()
                {
                    CarID = 2,
                    Make = "Complain",
                    YearOfModel = 2012
                },

                 new Car()
                {
                    CarID = 2,
                    Make = "Complain",
                    YearOfModel = 221
                },

                new Car()
                {
                    CarID = 2,
                    Make = "Whistle",
                    YearOfModel = 2012
                }


            };

        }

        public class Car
        {

            public int CarID { get; set; }
            public string Make { get; set; }
            public int YearOfModel { get; set; }

        }
    }
}
