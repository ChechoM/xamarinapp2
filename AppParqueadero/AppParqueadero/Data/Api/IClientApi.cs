using AppParqueadero.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppParqueadero.Data.Api
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClientsAsync();
        [Get("/Clients/{id}")]
        Task<Client> GetClientAsync(long id);
    }

}
