using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Entities
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public TipoHabitacion Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        private bool Disponible { get; set; }
        public int Capacidad { get; set; }


        private static readonly Dictionary<TipoHabitacion, decimal> Precios = new Dictionary<TipoHabitacion, decimal>
        {
            { TipoHabitacion.Económica, 100000m },
            { TipoHabitacion.Estándar, 150000m },
            { TipoHabitacion.Suite, 250000m }
        };

        public Habitacion(int idHabitacion, TipoHabitacion tipo, decimal precioPorNoche, bool disponible, int capacidad)
        {
            IdHabitacion = idHabitacion;
            Tipo = tipo;
            PrecioPorNoche = Precios[Tipo];
            Disponible = disponible;
            Capacidad = capacidad;
            Disponible = true;

        }

        public override string ToString()
        {
            return $"{IdHabitacion} - {Tipo} - {PrecioPorNoche} - {Disponible} - {Capacidad}";
        }
    }
}
