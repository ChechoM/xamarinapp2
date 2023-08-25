using AppParqueadero.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppParqueadero.Data.Api
{
    public interface ICalificacionesApi
    {
        [Post("/Calificaciones")]
        Task<HttpResponseMessage> PostCalificacionesAsync(object calificacionesService);

        [Get("/Calificaciones/Clientes{id}")]
        Task<List<Calificaciones>> GetCalificacionesPorCLiente(long id);
    }
}
