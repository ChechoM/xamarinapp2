using AppParqueadero.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppParqueadero.Data.Api
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClientsAsync();
    }

}
