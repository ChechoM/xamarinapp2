using System.Threading.Tasks;

namespace AppParqueadero.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }
}
