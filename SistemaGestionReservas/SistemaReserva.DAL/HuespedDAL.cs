using System;
using System.Collections.Generic;
using System.IO;
using SistemaReserva.Entities;

namespace SistemaReserva.DAL
{
    public class HuespedDAL
    {
        private static string filePath = "huespedes.txt";

        public static void Guardar(Huesped huesped)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{huesped.Identificacion},{huesped.Nombre}");
            }
        }

        public static List<Huesped> ObtenerTodos()
        {
            List<Huesped> huespedes = new List<Huesped>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        var datos = linea.Split(',');
                        huespedes.Add(new Huesped(int.Parse(datos[0]), datos[1]));
                    }
                }
            }
            return huespedes;
        }
    }
}