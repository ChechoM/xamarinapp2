using AppParqueadero.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace AppParqueadero.Services
{
    public class GoogleMapsService : IGoogleMapsService
    {

        public GoogleMapsService() { }

        public async Task<RutasGoogle> GetRuta(Position posicionInicial, Position posicionFinal)
        {
            string UrlBase = "https://maps.googleapis.com/maps/api/directions/json?";
            
            var parametros = new List<string>();
            parametros.Add(agregarParametrso("avoid", "highways"));
            parametros.Add(agregarParametrso("destination", $"{posicionFinal.Latitude}, {posicionFinal.Longitude}"));
            parametros.Add(agregarParametrso("mode", "DRIVING"));
            parametros.Add(agregarParametrso("origin", $"{posicionInicial.Latitude}, {posicionInicial.Longitude}"));
            parametros.Add(agregarParametrso("key", "AIzaSyA4n6z3GSPg9YqeKRFsnvvSsd2q9YpL9pI"));

            string UrlParametros = String.Concat(parametros).Substring(0, String.Concat(parametros).Length-1);
            HttpClientHandler httpClientHandler =  GetInsecureHandler();
            using (HttpClient client = new HttpClient(httpClientHandler))
            {

                HttpResponseMessage response = await client.GetAsync($"{UrlBase}{UrlParametros}");

                object objRespuesta = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                return Task.FromResult(objRespuesta);

            }
        }

        public string agregarParametrso(string key, string value)
        {
            return $"{key}={value}&";
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
