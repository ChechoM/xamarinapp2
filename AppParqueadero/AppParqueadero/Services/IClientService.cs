using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsAsync();
    }
}
