using SistemaReserva.DAL;
using SistemaReserva.Entities;
using System;

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

