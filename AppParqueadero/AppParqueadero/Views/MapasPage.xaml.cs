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
using System.Xml.Linq;
using System.Threading.Tasks;

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
            contenedorDetalle.IsVisible = false;
            ClientLocationMap.HeightRequest = 600;
            var positionFalsa = new Position(6.248932112041483, -75.57290152500107);
            ClientLocationMap.MoveToRegion(new MapSpan(positionFalsa, 0.05, 0.05));

            Pin MiUbicacion = new Pin() { Position = positionFalsa, Type = PinType.Place, Label = "mi Ubicacion falsa" };
            ClientLocationMap.Pins.Add(MiUbicacion);

            foreach (var item in _viewModel.Clients)
            {
                if (
                item.latitud != default &&
                item.longitud != default &&
                !string.IsNullOrEmpty(item.name))
                {
                    var position = new Position(Convert.ToDouble(item.latitud), Convert.ToDouble(item.longitud));

                    Pin pin = new Pin();
                    pin.Position = position;
                    pin.Label = $"{item.name} Valor hora ${item.valorHora}";
                    pin.Type = PinType.Place;


                    pin.MarkerClicked += (sender, e) => { Map_PinClicked(item, sender, position); };

                    ClientLocationMap.Pins.Add(pin);

                }
            }
            
            
            
        }
        private  async Task  Map_PinClicked(Client client, object sender, Position posicionClick)
        {
               
               
                _viewModel.Client = client;
                Position positionFalsa = new Position(6.248932112041483, -75.57290152500107);
                RutasGoogle rutasGoogle = await _viewModel._googleMapsService.GetRuta(positionFalsa, posicionClick);
                if (rutasGoogle != null)
                {
                    contenedorDetalle.IsVisible = true;
                    ClientLocationMap.HeightRequest = 400;

                }
                var Distancia = rutasGoogle.routes.Select(x => x.legs.Select(s => s.distance.text).FirstOrDefault()).FirstOrDefault();
                var TiempoEstimado = rutasGoogle.routes.Select(x => x.legs.Select(s => s.duration.text).FirstOrDefault()).FirstOrDefault();

                txtDistancia.Text = $"La distancia que debe recorrer es {Distancia}";
                txtTiempo.Text = $"El tiempo estimado en el recorrido es {TiempoEstimado}";

                var ruta = new Xamarin.Forms.Maps.Polyline
                {
                    StrokeColor = Color.Blue,
                    StrokeWidth = 10
                };

                if (rutasGoogle?.routes?.Any() == true)
                {
                    var route = rutasGoogle.routes.First();
                    var routeCoordinates = route.legs.SelectMany(leg => leg.steps.SelectMany(step => DecodePolylinePoints(step.polyline.points)));

                    foreach (var coordinate in routeCoordinates.ToList())
                    {
                        ruta.Geopath.Add(coordinate);
                    }
                    ClientLocationMap.MapElements.Clear();
                    ClientLocationMap.MapElements.Add(ruta);
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