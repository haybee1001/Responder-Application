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

namespace ResponderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrialPage : ContentPage
    {
        public IList<api> Items { get; set; }
        public TrialPage()
        {
            InitializeComponent();
           
        }


    }
}