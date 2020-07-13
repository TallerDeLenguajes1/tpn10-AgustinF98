using System.IO;
using System.Collections.Generic;
using System;

namespace TP10_1
{
    enum TipoDeOperacion
    {
        Venta,
        Alquiler
    }
    enum TipoDePropiedad
    {
        Departamento,
        Casa,
        Duplex,
        Penthhouse,
        Terreno
    }

    public class Propiedad
    {
        private int id;
        private TipoDePropiedad tipoPropiedad;
        private TipoDeOperacion tipoOperacion;
        private float tamanio;
        private int cantDeBanios;
        private int cantDeHabitaciones;
        private string domicilio;
        private int precio;
        private int valorInmueble;
        private bool estado; // activo/inactivo

        public int Id { get => id; set => id = value; }
        public float Tamanio { get => tamanio; set => tamanio = value; }
        public int CantDeBanios { get => cantDeBanios; set => cantDeBanios = value; }
        public int CantDeHabitaciones { get => cantDeHabitaciones; set => cantDeHabitaciones = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public int Precio { get => precio; set => precio = value; }
        public int ValorInmueble { get => valorInmueble; set => valorInmueble = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal TipoDePropiedad TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }
        internal TipoDeOperacion TipoOperacion { get => tipoOperacion; set => tipoOperacion = value; }

        public int ValorDelInmueble()
        {
            int valor = 0;
            int costoDeTransferencia = 10000;
            int IVA = precio * 21 / 100;
            int ingresosBrutos = precio * 10 / 100;
            int precioAlquiler = precio * 2 / 100;
            int selladoYContrato = precio * 5 / 1000;


            if (tipoOperacion == TipoDeOperacion.Venta)
            {
                valor = precio + IVA + costoDeTransferencia + ingresosBrutos;
            }
            else
            {
                valor = precio + precioAlquiler + selladoYContrato;
            }
            return valor;
        }
    }

    public static class HelperDeCargaDeDatos
    {
        public static void CargarDatos(int i, string domicilio, Propiedad propiedad)
        {
            Random rand = new Random();
            int estado = rand.Next(0, 1);
            int numAleatorio1 = rand.Next(0, 4);
            int numAleatorio2 = rand.Next(0, 1);

            propiedad.Id = i + 1;
            propiedad.CantDeBanios = rand.Next(1, 5);
            propiedad.CantDeHabitaciones = rand.Next(1, 5);
            propiedad.Domicilio = domicilio;
            propiedad.Precio = rand.Next(90000, 300000);
            propiedad.ValorInmueble = propiedad.ValorDelInmueble();
            propiedad.Tamanio = rand.Next(100, 500);

            switch (numAleatorio1)
            {
                case 0:
                    propiedad.TipoPropiedad = TipoDePropiedad.Departamento;
                    break;
                case 1:
                    propiedad.TipoPropiedad = TipoDePropiedad.Casa;
                    break;
                case 2:
                    propiedad.TipoPropiedad = TipoDePropiedad.Duplex;
                    break;
                case 3:
                    propiedad.TipoPropiedad = TipoDePropiedad.Penthhouse;
                    break;
                case 4:
                    propiedad.TipoPropiedad = TipoDePropiedad.Terreno;
                    break;
            }

            switch (numAleatorio2)
            {
                case 0:
                    propiedad.TipoOperacion = TipoDeOperacion.Venta;
                    break;
                case 1:
                    propiedad.TipoOperacion = TipoDeOperacion.Alquiler;
                    break;
            }

            if (estado == 1)
            {
                propiedad.Estado = true;
            } 
            else
            {
                propiedad.Estado = false;
            }
        }
    }

    public static class HelperDeArchivo
    {
        public static void CargarArchivo(List<Propiedad> ListaDePropiedades)
        {
            string nombreDeArchivo = "Propiedades.csv";
            string RutaArchivo = @"C:\Repogit\tp10\tpn10-AgustinF98\TP10_1\";
            string Linea;

            if (!File.Exists(RutaArchivo + nombreDeArchivo))
            {
                File.Create(RutaArchivo + nombreDeArchivo);
            }

            StreamWriter sw = new StreamWriter(File.Open(RutaArchivo + nombreDeArchivo, FileMode.OpenOrCreate));

            foreach (Propiedad propiedad in ListaDePropiedades)
            {
                Linea = "ID: " + propiedad.Id.ToString() + ";"
                    + "Tipo de propiedad: " + propiedad.TipoPropiedad.ToString() + ";"
                    + "Metros cuadrados: " + propiedad.Tamanio.ToString() + ";"
                    + "Operacion: " + propiedad.TipoOperacion + ";"
                    + "Banios: " + propiedad.CantDeBanios.ToString() + ";"
                    + "Habitaciones: " + propiedad.CantDeHabitaciones.ToString() + ";"
                    + "Domicilio: " + propiedad.Domicilio + ";"
                    + "Precio: " + propiedad.Precio.ToString() + ";"
                    + "Valor del inmueble: " + propiedad.ValorInmueble.ToString() + ";"
                    + "Estado: " + propiedad.Estado.ToString() + ";";
                sw.WriteLine(Linea);
            }

            sw.Close();
        }
    }
}