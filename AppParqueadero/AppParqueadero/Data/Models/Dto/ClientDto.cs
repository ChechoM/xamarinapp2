using System;
using System.Collections.Generic;
using System.Text;

namespace AppParqueadero.Data.Models.Dto
{
    public class ClientDto
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public float valorHora { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public string horarioAbre { get; set; }
        public string horarioCierre { get; set; }
        public bool techo { get; set; }
        public bool datafono { get; set; }
        public bool disponibilidad { get; set; }
            

    }
}
