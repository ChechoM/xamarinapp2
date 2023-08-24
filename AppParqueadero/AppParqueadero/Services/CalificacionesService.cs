using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    class CalificacionesService : ICalificacionesService
    {
        public ICalificacionesApi _CalificacionesApi;
        public IVisitasApi _IVisitasApi;

        public CalificacionesService(ICalificacionesApi calificacionesApi, IVisitasApi iVisitasApi)
        {
            _CalificacionesApi = calificacionesApi;
            _IVisitasApi = iVisitasApi;
        }
        public Task<HttpResponseMessage> PostCalificacionesAsync(Calificaciones calificaciones)
        {
           return _CalificacionesApi.PostCalificacionesAsync(calificaciones);
        }

        public string ValidarCalificacion(long id)
        {
            var respuesta = _IVisitasApi.ValidarVisitaAsync(id).Result.Content.ReadAsStringAsync().Result;

            return respuesta;
        }

    }
}
