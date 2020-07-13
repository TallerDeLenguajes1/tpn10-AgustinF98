using System;
using System.Collections.Generic;
using System.IO;
using TP10_1;

namespace TP10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Propiedad> ListaDePropiedades = new List<Propiedad>();
            Propiedad propiedad;
            Console.WriteLine("Ingrese la cantidad de propiedades: ");
            int cantPropiedades = Convert.ToInt32(Console.ReadLine());
            string domicilio;

            for (int i = 0; i<cantPropiedades; i++)
            {
                propiedad = new Propiedad();
                Console.WriteLine("Ingrese el domicilio de la propiedad N° " + (i+1) + ": ");
                domicilio = Console.ReadLine();
                HelperDeCargaDeDatos.CargarDatos(i, domicilio, propiedad);
                ListaDePropiedades.Add(propiedad);
            }

            HelperDeArchivo.CargarArchivo(ListaDePropiedades);
        }
    }
}
