using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test01_Introduccion_Cognos
{
    class Program
    {
        static int IdActualOperacion = 1;
        static int IdActualOrdenCarga = 1;

        // Variables Globales 
        static List<Operacion> Operaciones = new List<Operacion>();
        static List<OrdenCarga> OrdenesCarga = new List<OrdenCarga>();


        /*static ListaGenerica<int> la = new ListaGenerica<int>();
        static ListaGenerica<string> l2 = new ListaGenerica<string>();
        static ListaGenerica<Operacion> lOpe = new ListaGenerica<Operacion>();*/





        static int opciones;

        static void Main(string[] args)
        {
            CargarBaseDeDatosInicial();

            /*la.add(12);
            l2.add("dsad");
            lOpe.add(new Operacion { Descripcion = "21", Destino = "asd" });*/



            do
            {
                Console.WriteLine("Seleccione una de las siguiente opciones:\n\n1 => Registrar Operacion\n2 => Registrar Orden de Carga \n3 => Listar Operacion \n4 => Filtrar OPE por Ciudad LP \n5 => Eliminar Operacion con ID = 1\n0 => Salir de la aplicacion");

                opciones = Convert.ToInt32(Console.ReadLine());

                switch (opciones)
                {
                    case 1: // Registro operacion
                        Operacion NuevaOperacion = new Operacion();

                        NuevaOperacion.IdOperacion = IdActualOperacion;
                        IdActualOperacion++;

                        Console.Write("Nombre Operacion:\t");
                        NuevaOperacion.Nombre = Console.ReadLine();

                        Console.Write("Descripcion:\t");
                        NuevaOperacion.Descripcion = Console.ReadLine();

                        Console.Write("Flete Total:\t");
                        NuevaOperacion.FleteTotal = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Fecha:\t");
                        NuevaOperacion.Fecha = Console.ReadLine();

                        Console.Write("Empresa:\t");
                        NuevaOperacion.Empresa = Console.ReadLine();

                        Console.Write("Origen:\t");
                        NuevaOperacion.Origen = Console.ReadLine();

                        Console.Write("Destino:\t");
                        NuevaOperacion.Destino = Console.ReadLine();

                        // persistir
                        Operaciones.Add(NuevaOperacion);

                        Console.WriteLine("Registro de operacion exitoso!");
                        Console.WriteLine(NuevaOperacion);

                        Console.WriteLine("=====================================");

                        break;
                    case 2: // Registro orden de carga
                        // Listar las operaciones existentes
                        Console.WriteLine("===========LISTADO DE OPERACIONES ==========================");
                        foreach (var OperacionActual in Operaciones)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        Console.WriteLine("==================================================================");

                        Console.WriteLine("Seleccione el ID de la Operacion a la que pertencera la Orden de Carga");

                        int IdOperacion = Convert.ToInt32(Console.ReadLine());


                        if (Operaciones.Find(op => op.IdOperacion == IdOperacion) != null) // operacion existe
                        {

                            OrdenCarga NuevaOrdenCarga = new OrdenCarga();

                            NuevaOrdenCarga.IdOrdenCarga = IdActualOrdenCarga;
                            IdActualOrdenCarga++;

                            Console.Write("FechaInicio:\t");
                            NuevaOrdenCarga.FechaInicio = Console.ReadLine();

                            Console.Write("FechaFin:\t");
                            NuevaOrdenCarga.FechaFin = Console.ReadLine();

                            Console.Write("Chofer:\t");
                            NuevaOrdenCarga.Chofer = Console.ReadLine();

                            Console.Write("Honorarios:\t");
                            NuevaOrdenCarga.Honorarios = Convert.ToDouble(Console.ReadLine());

                            // Relacion 
                            NuevaOrdenCarga.IdOperacion = IdOperacion;

                            // persistir
                            OrdenesCarga.Add(NuevaOrdenCarga);

                            Console.WriteLine("Registro de orden de carga exitoso!");
                            Console.WriteLine(NuevaOrdenCarga);

                            Console.WriteLine("=====================================");

                        }
                        else // operacion inexistente
                        {
                            Console.WriteLine("ID de Operacion no encontrado");
                        }

                        break;
                    case 3: // Listar operaciones
                        Console.WriteLine("===========LISTADO DE OPERACIONES ==========================");
                        foreach (var OperacionActual in Operaciones)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        Console.WriteLine("==================================================================");
                        break;
                    case 4: // Filtro por ciudad LP
                        List<Operacion> resultado = filtrarOperacionesPorOrigenYDestino();
                        foreach (var OperacionActual in resultado)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        break;
                    case 5: // Eliminar Operacion con ID =1 
                        eliminarOperacionPorId();
                        break;

                    default:
                        Console.WriteLine("La opcion seleccionada es invalida, ingrese alguna de las opciones permitidas");
                        break;
                }



                /*var x = from example in Operaciones
                        join example2 in OrdenesCarga
                            on example.IdOperacion equals example2.IdOperacion
                        select new { a = example.IdOperacion, example2.FechaInicio };

                     var t=   x.Select(x => x.FechaInicio).ToList();*/


            } while (opciones != 0);


            /***
             * Opciones:
             *      1 => Registrar Operacion
             *      2 => Registrar Orden de Carga
             *      3 => Listar Operacion 
             *      0 => Salir de la aplicacion
             */


        }

        // 1. Filtrar Los operaciones cuyo origen sea igual a LP ( Origen == "LP" y Destino == "SC")
        static List<Operacion> filtrarOperacionesPorOrigenYDestino()
        {
            return Operaciones.Where((op) => op.Origen == "LP" && op.Destino == "SC").ToList();

            /*List<Operacion> listaFiltrada = new List<Operacion>();
            for (int i = 0; i < Operaciones.Count; i++)
            {
                Operacion opActual = Operaciones[i];
                if (opActual.Origen == "LP" && opActual.Destino == "SC")
                {
                    listaFiltrada.Add(opActual);
                }
            }
            return listaFiltrada;*/
        }


        // 2. Eliminar las ordenes de cargo cuyo ID de Operacion sea Igual 1
        static void eliminarOperacionPorId()
        {
            Operacion operacionBuscada = Operaciones.FirstOrDefault(x => x.IdOperacion == 1);
            if (operacionBuscada != null)
            { // si existe
                Operaciones.Remove(operacionBuscada);
                Console.WriteLine("Eliminacion exitosa");
            }
            else
            {
                Console.WriteLine("La Operacion de ID = 1 no existe en la base de datos");
            }
        }


        // 3. Ordenar las operaciones por Nombre de Empresa 
        // 4. Obtener la primera opearcion cuyo criterio XXX se cumpla



        public static void CargarBaseDeDatosInicial()
        {
            Operaciones.Add(new Operacion
            {
                IdOperacion = IdActualOperacion++,
                Nombre = "A",
                Fecha = "01001",
                Descripcion = "AB Desc",
                Empresa = "Pdsa",
                Origen = "AB",
                Destino = "SC",
                FleteTotal = 1000,
            });

            Operaciones.Add(new Operacion
            {
                IdOperacion = IdActualOperacion++,
                Nombre = "B",
                Fecha = "01001",
                Descripcion = "AB Desc",
                Empresa = "Pdsa",
                Origen = "LP",
                Destino = "CN",
                FleteTotal = 1000,
            });

            Operaciones.Add(new Operacion
            {
                IdOperacion = IdActualOperacion++,
                Nombre = "C",
                Fecha = "01sda001",
                Descripcion = "AB Desc",
                Empresa = "Pdsa",
                Origen = "LP",
                Destino = "SC",
                FleteTotal = 1000,
            });

            OrdenesCarga.Add(new OrdenCarga
            {
                IdOrdenCarga = IdActualOrdenCarga++,
                FechaInicio = "01020",
                FechaFin = "01020",
                Chofer = "juan",
                Honorarios = 21313,
                IdOperacion = 1
            }); ;

        }
    }
}
