using System;
using SistemaReserva.BLL;

namespace SistemaReservas.IU
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                MostrarMenu();
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1': RegistrarHuesped(); break;
                    case '2': RegistrarReserva(); break;
                    case '3': ConsultarReservas(); break;
                    case '4': CalcularCostoReserva(); break;
                    case '5': return;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void MostrarMenu()
        {
            string[] opciones = { "1. Registrar huésped", "2. Registrar reserva", "3. Consultar reservas", "4. Calcular costo", "5. Salir" };
            string titulo = "SISTEMA DE RESERVAS";
            DibujarRecuadro(30, titulo);
            foreach (string opcion in opciones)
            {
                Console.WriteLine("│ {0,-26} │", opcion);
            }
            DibujarLineaInferior(30);
            Console.Write("Seleccione una opción: ");
        }

        static void RegistrarHuesped()
        {
            Console.WriteLine("REGISTRO DE HUÉSPED");
            DibujarLinea(20);
            Console.Write("Identificación: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            HuespedBLL.RegistrarHuesped(id, nombre);
        }

        static void RegistrarReserva()
        {
            Console.WriteLine("REGISTRO DE RESERVA");
            DibujarLinea(20);
            Console.Write("ID Reserva: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("ID Habitación: ");
            int idHab = int.Parse(Console.ReadLine());
            Console.Write("ID Huésped: ");
            int idHuesped = int.Parse(Console.ReadLine());
            Console.Write("Fecha Entrada (yyyy-mm-dd): ");
            DateTime entrada = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha Salida (yyyy-mm-dd): ");
            DateTime salida = DateTime.Parse(Console.ReadLine());
            ReservaBLL.RegistrarReserva(id, idHab, idHuesped, entrada, salida);
        }

        static void ConsultarReservas()
        {
            Console.Write("ID Habitación: ");
            int idHab = int.Parse(Console.ReadLine());
            ReservaBLL.VisualizarReservas(idHab);
        }

        static void CalcularCostoReserva()
        {
            Console.Write("ID Reserva: ");
            int idRes = int.Parse(Console.ReadLine());
            ReservaBLL.CalcularCosto(idRes);
        }

        static void DibujarRecuadro(int ancho, string titulo)
        {
            Console.WriteLine("┌" + new string('─', ancho) + "┐");
            Console.WriteLine("│" + titulo.PadLeft((ancho / 2) + (titulo.Length / 2)).PadRight(ancho) + "│");
            DibujarLinea(ancho);
        }

        static void DibujarLinea(int ancho)
        {
            Console.WriteLine("├" + new string('─', ancho) + "┤");
        }

        static void DibujarLineaInferior(int ancho)
        {
            Console.WriteLine("└" + new string('─', ancho) + "┘");
        }
    }
}