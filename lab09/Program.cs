using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    internal class Program
    {
        static float caja = 0.0f;
        static float Limpieza = 0;
        static float Abarrotes = 0;
        static float Golosinas = 0;
        static float Electronicos = 0;
        static float devueltaLimpieza = 0;
        static float devueltaAbarrotes = 0;
        static float devueltosGolosinas = 0;
        static float devueltosElectronicos = 0;
        static void Main(string[] args)
        {
            MenuPrencipal();
            Console.ReadKey();
        }
        static void MenuPrencipal() 
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Tienda de Don Lucas");
            Console.WriteLine("=============================");
            Console.WriteLine("1: Registrar ventas");
            Console.WriteLine("2: Registrar devolucion");
            Console.WriteLine("3: Cerrar Caja");
            Console.WriteLine("=============================");
            Console.WriteLine("Ingrese una opcion");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion) 
            {
                case 1: Console.Clear();
                    RegistroVenta();
                        break;
                case 2: Console.Clear();
                    RegistroDevolucion();
                        break;
                case 3: Console.Clear();
                    CerrarCaja();
                        break;
            }
        }
        static void RegistroVenta() 
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Registrar Venta de:");
            Console.WriteLine("=============================");
            Console.WriteLine("1: Limpieza");
            Console.WriteLine("2: Abarrotes");
            Console.WriteLine("3: Golosinas");
            Console.WriteLine("4: Electronicos");
            Console.WriteLine("5: <- Regresar");
            Console.WriteLine("=============================");
            Console.WriteLine("Ingrese una opcion: ");
            int venta = int.Parse(Console.ReadLine());
            switch (venta) 
            {
                case 1: 
                    Venta("limpieza",ref Limpieza);
                    break;
                case 2: 
                    Venta("Abarrotes",ref Abarrotes);
                    break;
                case 3: 
                    Venta("Golosinas", ref Golosinas);
                    break;
                case 4: 
                    Venta("Electronicos", ref Electronicos);
                    break;
                case 5: 
                    MenuPrencipal();
                    break;
            }
        }
        static void RegistroDevolucion() 
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Registrar Devolucion de:");
            Console.WriteLine("=============================");
            Console.WriteLine("1: Limpieza");
            Console.WriteLine("2: Abarrotes");
            Console.WriteLine("3: Golosinas");
            Console.WriteLine("4: Electronicos");
            Console.WriteLine("5: <- Regresar");
            Console.WriteLine("=============================");
            Console.WriteLine("Ingrese una opcion: ");
            int devolucion = int.Parse(Console.ReadLine());
            switch (devolucion)
            {
                case 1:
                    Devolucion("limpieza", ref devueltaLimpieza);
                    break;
                case 2:
                    Devolucion("Abarrotes", ref devueltaAbarrotes);
                    break;
                case 3:
                    Devolucion("Golosinas", ref devueltosGolosinas);
                    break;
                case 4:
                    Devolucion("Electronicos", ref devueltosElectronicos);
                    break;
                case 5:
                    MenuPrencipal();
                    break;
            }
        }
        static void CerrarCaja() 
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Cerrando Caja");
            Console.WriteLine("=======================");
            Console.WriteLine("Totales");
            Console.WriteLine("=======================");

            MostrarEstadisticasPorRubro("Limpieza", Limpieza, devueltaLimpieza);
            MostrarEstadisticasPorRubro("Abarrotes", Abarrotes, devueltaAbarrotes);
            MostrarEstadisticasPorRubro("Golosinas", Golosinas, devueltosGolosinas);
            MostrarEstadisticasPorRubro("Electronicos", Electronicos, devueltosElectronicos);

            Console.WriteLine($"Queda en caja S/{caja:f2}");
            Console.ReadKey();
        }
        static void MostrarEstadisticasPorRubro(string rubro, float vendidos, float devueltos)
        {
            float total = vendidos - devueltos;

            Console.WriteLine($"\t\t| {vendidos} vendidos");
            Console.WriteLine($"{rubro} \t| {devueltos} devueltos");
            Console.WriteLine($"\t\t| {total} en total");
            Console.WriteLine($"\t\t| S/ {(total):f2} en caja");
            Console.WriteLine("=======================");
        }
        static void Venta(string TipoProducto, ref float Vendido) 
        {
            Console.Clear();
            float PrecioTV = 0;
            Console.WriteLine("====================================");
            Console.WriteLine("Registrar venta de "+TipoProducto);
            Console.WriteLine("====================================");
            Console.Write("Ingrese Cantidad (Unidades) ");
            int unidades = int.Parse(Console.ReadLine());
            Console.Write("Ingrese precio S/");
            Vendido = Vendido + unidades;
            float precio = float.Parse(Console.ReadLine());
            PrecioTV = unidades * precio;
            caja = caja + PrecioTV;
            Console.WriteLine("====================================");
            Console.WriteLine("Se han ingresado " + unidades + " unidades");
            Console.WriteLine("Se han ingresado S/"+PrecioTV+" en caja");
            Console.WriteLine("====================================");
            Console.WriteLine("1: Registrar mas productos de "+TipoProducto);
            Console.WriteLine("2: <- Regresar");
            Console.WriteLine("====================================");
            Console.WriteLine("Ingrese una opcion: ");
            int opcion = int.Parse(Console.ReadLine());

            if ( opcion == 1 ) 
            {
                Console.Clear();
                Venta(TipoProducto, ref Vendido);
            }
            else
            {
                Console.Clear();
                RegistroVenta();
            }
        }
        static void Devolucion(string TipoProducto, ref float devuelto)
        {
            float PrecioTD = 0;
            Console.WriteLine("====================================");
            Console.WriteLine("Registrar Devolucion de " + TipoProducto);
            Console.WriteLine("====================================");
            Console.Write("Ingrese Cantidad (Unidades) ");
            int unidades = int.Parse(Console.ReadLine());
            Console.Write("Ingrese precio S/");
            float precio = float.Parse(Console.ReadLine());
            PrecioTD = unidades * precio;
            caja -= PrecioTD;
            Console.WriteLine("====================================");
            Console.WriteLine("Se han regresado " + unidades + " unidades");
            Console.WriteLine("Se han devuelto S/" + PrecioTD    + " de caja");
            Console.WriteLine("====================================");
            Console.WriteLine("1: Devolver mas productos de "+TipoProducto);
            Console.WriteLine("2: <- Regresar");
            Console.WriteLine("====================================");
            Console.WriteLine("Ingrese una opcion: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.Clear();
                Devolucion(TipoProducto, ref devuelto);
            }
            else
            {
                Console.Clear();
                RegistroDevolucion();
            }
        }
    }
}
