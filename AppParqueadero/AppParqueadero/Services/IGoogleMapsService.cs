using AppParqueadero.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace AppParqueadero.Services
{
    public interface IGoogleMapsService
    {
        Task<RutasGoogle> GetRuta(Position posicionInicial, Position posicionFinal);
    }
}
