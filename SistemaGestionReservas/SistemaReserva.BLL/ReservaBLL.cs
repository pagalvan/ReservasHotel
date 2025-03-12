using System;
using System.Collections.Generic;
using System.Linq;
using SistemaReserva.Entities;
using SistemaReserva.DAL;

namespace SistemaReserva.BLL
{
    public class ReservaBLL
    {
        public static bool VerificarDisponibilidad(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            List<Reserva> reservas = ReservaDAL.ObtenerTodas(HabitacionDAL.ObtenerTodas(), HuespedDAL.ObtenerTodos());
            return !reservas.Any(r => r.Habitacion.IdHabitacion == idHabitacion &&
                                      ((fechaEntrada >= r.FechaEntrada && fechaEntrada < r.FechaSalida) ||
                                       (fechaSalida > r.FechaEntrada && fechaSalida <= r.FechaSalida)));
        }

        public static void RegistrarReserva(int id, int idHabitacion, int idHuesped, DateTime fechaEntrada, DateTime fechaSalida)
        {
            if (!VerificarDisponibilidad(idHabitacion, fechaEntrada, fechaSalida))
            {
                Console.WriteLine("Error: La habitación no está disponible en esas fechas.");
                return;
            }

            Habitacion habitacion = HabitacionDAL.ObtenerTodas().FirstOrDefault(h => h.IdHabitacion == idHabitacion);
            Huesped huesped = HuespedDAL.ObtenerTodos().FirstOrDefault(h => h.Identificacion == idHuesped);

            if (habitacion == null || huesped == null)
            {
                Console.WriteLine("Error: Habitación o huésped no encontrados.");
                return;
            }

            Reserva nuevaReserva = new Reserva(id, fechaEntrada, fechaSalida, habitacion, huesped);
            ReservaDAL.Guardar(nuevaReserva);
            Console.WriteLine("Reserva registrada con éxito.");
        }

        public static decimal CalcularCosto(int idReserva)
        {
            List<Reserva> reservas = ReservaDAL.ObtenerTodas(HabitacionDAL.ObtenerTodas(), HuespedDAL.ObtenerTodos());
            Reserva reserva = reservas.FirstOrDefault(r => r.Id == idReserva);

            if (reserva == null)
            {
                Console.WriteLine("Error: Reserva no encontrada.");
                return 0;
            }

            int noches = (int)(reserva.FechaSalida - reserva.FechaEntrada).TotalDays;
            decimal costoTotal = noches * reserva.Habitacion.PrecioPorNoche;
            Console.WriteLine($"Costo total de la estancia: {costoTotal:C}");
            return costoTotal;
        }

        public static void VisualizarReservas(int idHabitacion)
        {
            List<Reserva> reservas = ReservaDAL.ObtenerTodas(HabitacionDAL.ObtenerTodas(), HuespedDAL.ObtenerTodos());
            var reservasFiltradas = reservas.Where(r => r.Habitacion.IdHabitacion == idHabitacion);

            if (!reservasFiltradas.Any())
            {
                Console.WriteLine("No hay reservas para esta habitación.");
                return;
            }

            foreach (var reserva in reservasFiltradas)
            {
                Console.WriteLine(reserva);
            }
        }
    }

    public class HuespedBLL
    {
        public static void RegistrarHuesped(int identificacion, string nombre)
        {
            Huesped nuevoHuesped = new Huesped(identificacion, nombre);
            HuespedDAL.Guardar(nuevoHuesped);
            Console.WriteLine("Huésped registrado con éxito.");
        }
    }
}
