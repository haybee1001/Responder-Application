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

        double latt, lngg;
        public TaskDetails(string fault, string lat, string lng, string reportername, string incidenceId)
        {
            InitializeComponent();
            latt = double.Parse(lat);
            lngg = double.Parse(lng);
            lblIncidenceID.Text = incidenceId;

            GetAddressFromCordinate(latt, lngg, reportername);

            Pin pinTokyo = new Pin()
            {
                Type = PinType.Place,
                Label = "Location",
                Address = "sdsdsds",

                // Position = new Position(6.44231841433793, 7.48507842421532),
                Position = new Position(latt,lngg),
                Tag = "Id_Tokyo"
            };

            map.Pins.Add(pinTokyo);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinTokyo.Position, Distance.FromMeters(5000)));

        }

        public async void GetAddressFromCordinate(double _lat, double _lng, string reportername)
        {
            try
            {
                var lat = _lat;
                var lon = _lng;

                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var geocodeAddress = placemark.SubAdminArea + ", " + placemark.SubLocality;

                    Console.WriteLine(geocodeAddress);

                    lblAddress.Text = geocodeAddress;
                    lblReporterName.Text = reportername;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
        }

        public async void navigateClick()
        {
        }

        private void StartWorkTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Startwork());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Task.Delay(800);

            var location = new Location(latt,lngg);
            var options = new MapLaunchOptions {Name = "Location Name" };
            //Launching Maps

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }
} 