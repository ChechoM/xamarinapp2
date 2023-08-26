using System;
using System.Collections.Generic;
using System.Text;

namespace AppParqueadero.Data.Models.Dto
{
    public class ReporteVisitasDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public int Recaudo { get; set; }
        public int PromedioCalificacion { get; set; }
        public double CantidadVisitas { get; set; }
    }
 
}