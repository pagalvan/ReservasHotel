using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Entities
{
    public class Huesped
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }

        public Huesped()
        {
        }

        public Huesped(int identificacion, string nombre)
        {
            Identificacion = identificacion;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Identificacion} - {Nombre}";
        }
    }
}