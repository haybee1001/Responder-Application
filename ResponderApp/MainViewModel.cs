using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ResponderApp.ViewModell
{
    public class MainViewModel
    {
        private ProductModel _OldProduct;
        public ObservableCollection<ProductModel> Products;

        public MainViewModel()
        {
            Products = new ObservableCollection<ProductModel>()
            {
                new ProductModel
                {
                    Charges = "500",
                    ProductName = "Phone",
                    Description = "Phone Desc",
                    ImageUrl = "ab.jpg",
                    ColImage = "hollow.png",
                    ExpImage = "hollow_green.png",
                    IsVisisble = true,

                    Product_Details = new ObservableCollection<ProductDetails> {
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"},
                        new ProductDetails {Key= "Anil", Value ="Paragati"}
                  }
                }
            };
         }
           
            

        public class ProductModel
        {

            public string Name { get; set; }
            public bool IsVisisble { get; set; }
            public string ProductName { get; set; }
            public string Charges { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; }
            public string ColImage { get; set; }
            public string ExpImage { get; set; }
            public ObservableCollection<ProductDetails> Product_Details { get; set; }
        }

        public class ProductDetails
        {
            public string Key { get; set; }
            public string  Value { get; set; }
        }

    }
}
