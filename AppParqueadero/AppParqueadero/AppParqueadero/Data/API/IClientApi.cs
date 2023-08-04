using AppParqueadero.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace AppParqueadero.Data.API
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClients();
    }

}
