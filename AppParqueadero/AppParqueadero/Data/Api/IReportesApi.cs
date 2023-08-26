using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Data.Api
{
    public interface IReportesApi
    {
        [Get("/Reportes/ReporteVisitasPorUsuario{id}")]
        Task<List<ReporteVisitasDto>> GetCalificacionesPorCLiente(long id);
    }
}
