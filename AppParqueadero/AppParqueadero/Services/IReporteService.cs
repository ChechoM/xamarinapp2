using AppParqueadero.Data.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    public interface IReporteService
    {
        Task<List<ReporteVisitasDto>> GetCalificacionesPorCLiente(long id);
    }
}