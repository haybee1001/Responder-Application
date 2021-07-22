using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ResponderApp
{
    public class mviewmodel
    {
       // private ProductModel _OldProduct;

        public List<ProductModel> Products;
        public mviewmodel()
        {
            Products = new List<ProductModel>()
            {
                new ProductModel
                {
                    Charges = "500",
                    ProductName = "Phone",
                    Description = "Phone Desc",
                    ImageUrl = "ab.jpg",
                    ColImage = "hollow.png",
                    ExpImage = "hollow_green.png",
                    IsVisisble = false,
                }
            };

           
           
        }

        public class ProductModel
        {
            public bool IsVisisble { get; set; }
            public string ProductName { get; set; }
            public string Charges { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; }
            public string ColImage { get; set; }
            public string ExpImage { get; set; }
         
        }

        public class ProductDetails
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
