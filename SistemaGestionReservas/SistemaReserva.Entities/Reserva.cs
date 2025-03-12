using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        //GRASP CREATOR
        public Habitacion Habitacion { get; set; }
        public Huesped Huesped { get; set; }

        public Reserva()
        {
        }

        public Reserva(int id, DateTime fechaEntrada, DateTime fechaSalida, Habitacion habitacion, Huesped huesped)
        {
            Id = id;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            Habitacion = habitacion;
            Huesped = huesped;
        }

        public override string ToString()
        {
            return $"{Id} - {FechaEntrada} - {FechaSalida} - {Habitacion} - {Huesped}";
        }
    }
}
