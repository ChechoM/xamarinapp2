using System;
using System.Collections.Generic;
using System.Text;

namespace AppParqueadero.Data.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Dna { get; set; } = string.Empty;
    }

}
