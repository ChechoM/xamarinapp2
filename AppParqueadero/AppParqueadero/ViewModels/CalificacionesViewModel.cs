using AppParqueadero.Data.Models;
using AppParqueadero.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppParqueadero.ViewModels
{
    class CalificacionesViewModel :BaseViewModel
    {
        private readonly ICalificacionesService _calificacionesService;
        public CalificacionesViewModel(ICalificacionesService calificacionesService) 
        {
            EnviarCalificacion = new Command(calificarParqueadero);
            _calificacionesService = calificacionesService; 
        }

        public Command EnviarCalificacion { get; }

        private string _Comentario;
        private int _Calificacion;
        private long _IdVisita;    

        public string Comentario { get => _Comentario; set => SetProperty(ref _Comentario, value); }
        public int Calificacion { get => _Calificacion; set => SetProperty(ref _Calificacion, value); }
        public long IdVisita { get => _IdVisita; set => SetProperty(ref _IdVisita, value); }

        public async void calificarParqueadero(object obj)
        {
            var respuesta = await _calificacionesService.ValidarCalificacion(IdVisita);
            if (respuesta == "Ok") 
            {
                Calificaciones calificaciones = new Calificaciones()
                {
                    IdVisita = IdVisita,
                    Calificacion = Calificacion,
                    Comentario = Comentario
                };

                
                var respuestaPost = await _calificacionesService.PostCalificacionesAsync(calificaciones);
            }
        }
    }
}
