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
        public async Task<HttpResponseMessage> PostCalificacionesAsync(Calificaciones calificaciones)
        {
           var respuesta =  await _CalificacionesApi.PostCalificacionesAsync(calificaciones);
            return respuesta;
        }

        public async Task<string> ValidarCalificacion(long id)
        {
            
            var respuesta = await _IVisitasApi.ValidarVisitaAsync(id);
            var respuestaString = await respuesta.Content.ReadAsStringAsync();
            return respuestaString;


        }

    }
}
