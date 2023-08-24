using AppParqueadero.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Data.Api
{
    internal interface IVisitasApi
    {
        [Get("/Visitas/ValidarVisita")]
        Task<HttpResponseMessage> ValidarVisitaAsync(long id);
    }
}
