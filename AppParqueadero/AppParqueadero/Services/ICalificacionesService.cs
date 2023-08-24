using AppParqueadero.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    interface ICalificacionesService
    {
        public Task<HttpResponseMessage> PostCalificacionesAsync(Calificaciones calificaciones);
        public Task<string> ValidarCalificacion(long id);
    }
}
