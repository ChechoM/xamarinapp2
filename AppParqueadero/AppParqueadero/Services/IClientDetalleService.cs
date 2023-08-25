using AppParqueadero.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    public interface IClientDetalleService
    {

        Task<Client> GetClientAsync(long id);
    }
}
