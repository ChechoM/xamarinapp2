using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Resx;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppParqueadero.Services
{
    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly IGoogleApi _googleApi;
        public GoogleMapsService(IGoogleApi googleApi) 
        {
            _googleApi = googleApi;
        }

        public  RutasGoogle GetRuta(Position posicionInicial, Position posicionFinal)
        {
            RutasGoogle objRespuesta = new RutasGoogle();
            try
            {
                string origin = $"{posicionInicial.Latitude},{posicionInicial.Longitude}";
                string destino = $"{posicionFinal.Latitude},{posicionFinal.Longitude}";

                string UrlBase = "https://maps.googleapis.com/maps/api/directions/json?";

                var parametros = new List<string>();
                parametros.Add(agregarParametrso("avoid", "highways"));
                parametros.Add(agregarParametrso("destination", $"{destino}"));
                parametros.Add(agregarParametrso("mode", "DRIVING"));
                parametros.Add(agregarParametrso("origin", $"{origin}"));
                parametros.Add(agregarParametrso("key", "AIzaSyA4n6z3GSPg9YqeKRFsnvvSsd2q9YpL9pI"));

                string UrlParametros = String.Concat(parametros).Substring(0, String.Concat(parametros).Length - 1);
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {

                    HttpResponseMessage response = client.GetAsync($"{UrlBase}{UrlParametros}").Result;

                    objRespuesta = JsonConvert.DeserializeObject<RutasGoogle>(response.Content.ReadAsStringAsync().Result);

                    return objRespuesta;

                }
            }
            catch
            {
                 Application.Current.MainPage.DisplayAlert("Error",
                       "Disculpas error integrando con google verifique de nuevo mas tarde",
                       "acept");
            }
            finally
            {

            }
            return objRespuesta;


        }

        
        public string agregarParametrso(string key, string value)
        {
            return $"{key}={value}&";
        }

    }
}
