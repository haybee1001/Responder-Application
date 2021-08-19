using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ResponderApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetails : ContentPage
    {
        public Command SendCommand { get; }
        public TaskDetails(string fault)
        {
            InitializeComponent();
            mylabel1.Text = fault;

            Pin pinTokyo = new Pin()
            {
                Type = PinType.Place,
                Label = "Location",
                Address = "sdsdsds",
              
                Position = new Position(6.44231841433793, 7.48507842421532),
                Tag = "Id_Tokyo"
            };

            map.Pins.Add(pinTokyo);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinTokyo.Position, Distance.FromMeters(5000)));

        }


        public async void navigateClick()
        {
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Task.Delay(800);

            var location = new Location(6.4648580000,7.5335300000);
            var options = new MapLaunchOptions {Name = "Disney World" };
            //Launching Maps

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }
} 