using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ResponderApp
{
    public class tabViewmodel
    {
        public ObservableCollection<menu> Items { get; set; }

        public tabViewmodel()
        {
            Items = new ObservableCollection<menu>() {
                new menu()
                {
                    Title = "Home",
                    Image = "homee.png"

                },
                  new menu()
                {
                    Title = "Home",
                    Image = "homee.png"

                },
                    new menu()
                {
                    Title = "Home",
                    Image = "homee.png"

                },
                      new menu()
                {
                    Title = "Home",
                    Image = "homee.png"

                }
            };
        }

        public class menu
        {
            public string Title { get; set; }
            public string Image { get; set; }

        }
    }
}
