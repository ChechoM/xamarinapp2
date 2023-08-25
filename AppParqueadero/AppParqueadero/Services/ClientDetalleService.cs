using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppParqueadero.Services
{
    public class ClientDetalleService: IClientDetalleService
    {
        readonly IClientApi _clientApi;
        public ClientDetalleService( IClientApi client) 
        {
            _clientApi = client;
        
        }

        public async Task<Client> GetClientAsync(long id)
        {
            var clients = new Client();
            try
            {   if (id == 0) 
                {
                    await Application.Current.MainPage.DisplayAlert("Error",
                       "Disculpas con el envio de el id del cliente vuelva a intentarlo",
                       "acept");
                    return clients;
                }
                else 
                { 
                    var respuesta = await _clientApi.GetClientAsync(id);
                    clients = respuesta;

                    return clients;
                }
                

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }


            return clients;
        }
    }
}
