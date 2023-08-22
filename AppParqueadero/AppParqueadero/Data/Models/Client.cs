namespace AppParqueadero.Data.Models
{
    public class Client
    {
        public long id { get; set; }
        public string name { get; set; }
        public string nit { get; set; }
        public double valorHora { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public string horarioAbre { get; set; }
        public string horarioCierre { get; set; }
        public bool techo { get; set; }
        public bool datafono { get; set; }
        public bool disponibilidad { get; set; }
        public string longitud { get; set; }
        public string latitud { get; set; }
        public long userId { get; set; }
        public User user { get; set; }
    }
    
}
