using SistemaReserva.Entities;
using System.Collections.Generic;
using System.IO;
using System;

namespace SistemaReserva.DAL
{
    public class ReservaDAL
{
    private static string filePath = "reservas.txt";

    public static void Guardar(Reserva reserva)
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"{reserva.Id},{reserva.FechaEntrada},{reserva.FechaSalida},{reserva.Habitacion.IdHabitacion},{reserva.Huesped.Identificacion}");
        }
    }

    public static List<Reserva> ObtenerTodas(List<Habitacion> habitaciones, List<Huesped> huespedes)
    {
        List<Reserva> reservas = new List<Reserva>();
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    var datos = linea.Split(',');
                    reservas.Add(new Reserva(
                        int.Parse(datos[0]),
                        DateTime.Parse(datos[1]),
                        DateTime.Parse(datos[2]),
                        habitaciones.Find(h => h.IdHabitacion == int.Parse(datos[3])),
                        huespedes.Find(h => h.Identificacion == int.Parse(datos[4]))
                    ));
                }
            }
        }
        return reservas;
    }
}
}