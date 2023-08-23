using AppParqueadero.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Data.Api
{
    public interface IGoogleApi
    {
        [Get("/Clients/GetRutas")]
        Task<HttpResponseMessage> GetClientsRutasAsync(string origin, string destino);
    }
}
