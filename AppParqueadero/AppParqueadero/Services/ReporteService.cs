using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReportesApi _reportesApi;
        public ReporteService(IReportesApi  reportesApi) 
        {
           _reportesApi = reportesApi;
        }


        public async Task<List<ReporteVisitasDto>> GetCalificacionesPorCLiente(long id)
        {
            List<ReporteVisitasDto> response = new List<ReporteVisitasDto>();
            try
            {
                response = await _reportesApi.GetCalificacionesPorCLiente(id);

            }catch (Exception ex)
            {
                var error = ex.Message;
            }

            return response;
        }

    }
}
