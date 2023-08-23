using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using AppParqueadero.ViewModels;
using System;
using Xamarin.Essentials;
using System.Collections.Generic;
using AppParqueadero.Services;
using Newtonsoft.Json;
using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models;
using System.Linq;

namespace AppParqueadero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapasPage : ContentPage
    {
        private readonly MapasViewModel _viewModel;
        public MapasPage()
        {
            _viewModel = Startup.Resolve<MapasViewModel>();
            BindingContext = _viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
            InitializeComponent();
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var positionFalsa = new Position(6.248932112041483, -75.57290152500107);
            ClientLocationMap.MoveToRegion(new MapSpan(positionFalsa, 0.05, 0.05));

            foreach (var item in _viewModel.Client)
                {
                    if (
                    item.latitud != default &&
                    item.longitud != default &&
                    !string.IsNullOrEmpty(item.name))
                    {
                        var position = new Position(Convert.ToDouble(item.latitud), Convert.ToDouble(item.longitud));

                        Pin pin = new Pin();
                        //pin.MarkerClicked += Map_PinClicked(position);                        
                        pin.Position = position;
                        pin.Label = item.name;
                        pin.Type = PinType.Place;

                        ClientLocationMap.Pins.Add(pin);




                    }
                }
        }
        private   void Map_PinClicked(object sender, MapClickedEventArgs e)
        {
            
            Position positionFalsa = new Position(6.248932112041483, -75.57290152500107);
            Position posicionClick = new Position(e.Position.Latitude, e.Position.Longitude);

            RutasGoogle rutasGoogle = _viewModel._googleMapsService.GetRuta(positionFalsa, posicionClick);
            var ruta = new Xamarin.Forms.Maps.Polyline
            {
                StrokeColor = Color.Black,
                StrokeWidth = 4
            };

            if (rutasGoogle?.routes?.Any() == true)
            {
                var route = rutasGoogle.routes.First();
                var routeCoordinates = route.legs.SelectMany(leg => leg.steps.SelectMany(step => DecodePolylinePoints(step.polyline.points)));
               

                foreach (var coordinate in routeCoordinates.ToList())
                {
                    ruta.Geopath.Add(coordinate);
                }
            }
        }

        private IEnumerable<Position> DecodePolylinePoints(string encodedPoints)
        {
            int index = 0;
            int lat = 0;
            int lng = 0;

            while (index < encodedPoints.Length)
            {
                int b;
                int shift = 0;
                int result = 0;

                do
                {
                    b = encodedPoints[index++] - 63;
                    result |= (b & 0x1f) << shift;
                    shift += 5;
                }
                while (b >= 0x20);

                lat += ((result & 1) == 1 ? ~(result >> 1) : (result >> 1));

                shift = 0;
                result = 0;

                do
                {
                    b = encodedPoints[index++] - 63;
                    result |= (b & 0x1f) << shift;
                    shift += 5;
                }
                while (b >= 0x20);

                lng += ((result & 1) == 1 ? ~(result >> 1) : (result >> 1));

                yield return new Position(lat * 1e-5, lng * 1e-5);
            }
        }
    }
}