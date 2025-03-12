using System;
using System.Collections.Generic;
using System.IO;
using SistemaReserva.Entities;

namespace SistemaReserva.DAL
{
    public class HabitacionDAL
    {
        private static string filePath = "habitaciones.txt";

        public static void Guardar(Habitacion habitacion)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{habitacion.IdHabitacion},{habitacion.Tipo},{habitacion.PrecioPorNoche},{habitacion.Capacidad},{habitacion.EsDisponible()}");
            }
        }

        public static List<Habitacion> ObtenerTodas()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        var datos = linea.Split(',');
                        habitaciones.Add(new Habitacion(
                            int.Parse(datos[0]),
                            (TipoHabitacion)Enum.Parse(typeof(TipoHabitacion), datos[1]),
                            decimal.Parse(datos[2]),
                            bool.Parse(datos[4]),
                            int.Parse(datos[3])
                        ));
                    }
                }
            }
            return habitaciones;
        }
    }
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
            PrecioPorNoche = precioPorNoche;
            Disponible = disponible;
            Capacidad = capacidad;
        }

        public bool EsDisponible()
        {
            return Disponible;
        }

        public override string ToString()
        {
            return $"{IdHabitacion},{Tipo},{PrecioPorNoche},{Capacidad},{Disponible}";
        }
    }
}
