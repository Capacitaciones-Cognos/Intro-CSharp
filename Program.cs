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

        private class OrdenCargaDTO
        {
            public int IdOperacion { get; set; }
            public string Operacion { get; set; }
            public double Flete { get; set; }
            public string Empresa { get; set; }

            public int IdOrdenCarga { get; set; }
            public double Honorarios { get; set; }
            public string NombreChofer { get; set; }

            public override string ToString()
            {
                return $"IdOperacion: {IdOperacion}, Operacion: {Operacion}, Flete: {Flete}, Empresa: {Empresa}, IdOrdenCarga: {IdOrdenCarga}, Honorarios: {Honorarios}, NombreChofer: {NombreChofer}";
            }
        }


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
                Console.WriteLine("Seleccione una de las siguiente opciones:\n\n1 => Registrar Operacion\n2 => Registrar Orden de Carga \n3 => Listar Operacion \n4 => Filtrar OPE por Ciudad Destino y Origen \n5 => Eliminar Operacion con ID \n6 => Listar las ordenes de carga \n7 => Consulta: Listar Ordenes de Carga junto con la Operacion a la que pertenece \n8 Obtener Orden de Carga Personalizada por ID \n9=>Filtro por Nombre de chofer, FleteTotal y empresa \n10=>Filtro por operacion y numero de elementos\n0 => Salir de la aplicacion");

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
                        Console.WriteLine("===========LISTADO DE OPERACIONES ==========================");
                        foreach (var OperacionActual in Operaciones)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        Console.WriteLine("==================================================================");

                        Console.WriteLine("Seleccione el ID de la Operacion a la que pertencera la Orden de Carga");
                        string origen, destino;
                        Console.WriteLine("Introduzca el Origen");
                        origen = Console.ReadLine();
                        Console.WriteLine("Introduzca el Destino");
                        destino = Console.ReadLine();
                        List<Operacion> resultado = filtrarOperacionesPorOrigenYDestino(origen, destino);
                        foreach (var OperacionActual in resultado)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        break;
                    case 5: // Eliminar Operacion con ID =1 
                        Console.WriteLine("===========LISTADO DE OPERACIONES ==========================");
                        foreach (var OperacionActual in Operaciones)
                        {
                            Console.WriteLine(OperacionActual);
                        }
                        Console.WriteLine("==================================================================");

                        Console.WriteLine("Seleccione el ID de la Operacion que desee eliminar");
                        int idEliminar;

                        idEliminar = Convert.ToInt32(Console.ReadLine());
                        eliminarOperacionPorId(idEliminar);
                        break;

                    case 6: // Listar las ordenes de carga
                        Console.WriteLine("===========LISTADO DE ORDENES DE CARGA ==========================");
                        foreach (var ordenCarga in OrdenesCarga)
                        {
                            Console.WriteLine(ordenCarga);
                        }
                        Console.WriteLine("==================================================================");
                        break;

                    case 7:
                        Console.WriteLine("===========LISTADO DE ORDENES DE CARGA (CON OPERACION) ==========================");
                        // List<Operacion> o List<OrdenCarga>???
                        // DATOS A MOSTRAR  Op:
                        //              IdOperacion, Nombre, FleteTotal, Empresa
                        // DATOS A MOSTRAR  Oc:
                        //              IdOrdenCarga, Honorarios, Chofer
                        var listaCustomizadaOC = listarOrdenesDeCargaConRelaciones();
                        foreach (var ocPersonalizado in listaCustomizadaOC)
                        {
                            Console.WriteLine(ocPersonalizado);
                        }
                        Console.WriteLine("==================================================================");
                        break;


                    case 8: // Obtener Orden de Carga Personalizada por Identificador
                        Console.Write("Seleccione el ID de la Orden de carga que desea visualizar: ");
                        int idOc;
                        idOc = Convert.ToInt32(Console.ReadLine());

                        OrdenCargaDTO ordenCargaEncontrada = buscarOrdenCargaPersonalizadoPorId(idOc);

                        if (ordenCargaEncontrada != null)
                        { // si existe
                            Console.WriteLine(ordenCargaEncontrada);
                        }
                        else
                        {
                            Console.WriteLine("La Orden de Carga de ID =" + idOc + " no existe en la base de datos");
                        }

                        break;

                    /*
                     * Trabajar con el mismo objeto creado en clase OrdenCargaDTO y realizar la siguiente consulta:
                     * Obtener las ordenes de carga filtradas por Nombre de chofer, FleteTotal y empresa (excluyentes)
                     */
                    case 9: // 
                        string chofer,empresa;
                        double fleteTotal;
                        Console.Write("Introduzca el nombre del chofer: ");
                        chofer = Console.ReadLine();
                        Console.Write("Introduzca el nombre de la empresa: ");
                        empresa = Console.ReadLine();
                        Console.Write("Introduzca el monto del Flete: ");
                        //fleteTotal = Convert.ToDouble(Console.ReadLine());
                        bool conversionFlete = double.TryParse(Console.ReadLine(), out fleteTotal);
                        if (conversionFlete==false)
                        {
                            fleteTotal = -100;
                        }
                        var listaOcporOp = buscarOcporChoferFleteEmpresa(chofer, fleteTotal, empresa);
                        Console.WriteLine("===========LISTADO DE ORDENES DE CARGA DE LA OPERACION CON LOS DATOS: CHOFER: "+ chofer+ " FLETETOTAL: "+ fleteTotal+ " EMPRESA: "+empresa +" ===========================");
                        foreach (var ocPersonalizado in listaOcporOp)
                        {
                            Console.WriteLine(ocPersonalizado);
                        }
                        Console.WriteLine("==================================================================");
                        break;
                       

                     /*
                     * Trabajar con un nuevo DTO personalizado (a criterio propio), construido en base a las clases: Operacion y OrdenCarga
                     * Obtener el listado de los N primeros elementos (N parametrizado por consola) 
                     */
                    case 10:
                        Console.Write("Seleccione el ID de la Operacion para ver sus Ordenes de Carga: ");
                        int idOp;
                        idOp = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Seleccione la cantidad de elementos a visualizar: ");
                        int cantidadElementos;
                        cantidadElementos = Convert.ToInt32(Console.ReadLine());
                        var listaTarea = ordenesdeCargaPorOperacion(idOp, cantidadElementos);
                        Console.WriteLine("===========LISTADO DE ORDENES DE CARGA DE LA OPERACION: idOp ===========================");
                        foreach (var ocPersonalizado in listaTarea)
                        {
                            Console.WriteLine(ocPersonalizado);
                        }
                        Console.WriteLine("==================================================================");
                        break;

                    default:
                        Console.WriteLine("La opcion seleccionada es invalida, ingrese alguna de las opciones permitidas");
                        break;
                }






            } while (opciones != 0);


            /***
             * Opciones:
             *      1 => Registrar Operacion
             *      2 => Registrar Orden de Carga
             *      3 => Listar Operacion 
             *      0 => Salir de la aplicacion
             */
        }




        private static OrdenCargaDTO buscarOrdenCargaPersonalizadoPorId(int idOc)
        {
            var tuplas = from op in Operaciones
                         join oc in OrdenesCarga
                             on op.IdOperacion equals oc.IdOperacion
                         where oc.IdOrdenCarga == idOc
                         select new OrdenCargaDTO
                         {
                             IdOperacion = op.IdOperacion,
                             Operacion = op.Nombre,
                             Flete = op.FleteTotal,
                             Empresa = op.Empresa,
                             IdOrdenCarga = oc.IdOrdenCarga,
                             Honorarios = oc.Honorarios,
                             NombreChofer = oc.Chofer
                         };

            return tuplas.ToList().FirstOrDefault();
            
        }
      
        static List<OrdenCargaDTO> buscarOcporChoferFleteEmpresa(string chofer, double? flete, string empresa)
        {
            
            if (string.IsNullOrEmpty(empresa))
            {
                if (flete == -100)
                {
                    var tuplas = from op in Operaciones
                                 join oc in OrdenesCarga
                                 on op.IdOperacion equals oc.IdOperacion
                                 where oc.Chofer == chofer 
                                 select new OrdenCargaDTO
                                 {
                                     IdOperacion = op.IdOperacion,
                                     IdOrdenCarga = oc.IdOrdenCarga,
                                     Operacion = op.Nombre,
                                     Flete = op.FleteTotal,
                                     Empresa = op.Empresa,
                                     Honorarios = oc.Honorarios,
                                     NombreChofer = oc.Chofer
                                 };
                    return tuplas.ToList();
                }
                else 
                {
                    var tuplas = from op in Operaciones
                                 join oc in OrdenesCarga
                                 on op.IdOperacion equals oc.IdOperacion
                                 where oc.Chofer == chofer  && op.FleteTotal == flete 
                                 select new OrdenCargaDTO
                                 {
                                     IdOperacion = op.IdOperacion,
                                     IdOrdenCarga = oc.IdOrdenCarga,
                                     Operacion = op.Nombre,
                                     Flete = op.FleteTotal,
                                     Empresa = op.Empresa,
                                     Honorarios = oc.Honorarios,
                                     NombreChofer = oc.Chofer
                                 };
                    return tuplas.ToList();
                }
                
            }else if(flete == -100)
            {
                var tuplas = from op in Operaciones
                             join oc in OrdenesCarga
                             on op.IdOperacion equals oc.IdOperacion
                             where oc.Chofer == chofer  && op.Empresa == empresa
                             select new OrdenCargaDTO
                             {
                                 IdOperacion = op.IdOperacion,
                                 IdOrdenCarga = oc.IdOrdenCarga,
                                 Operacion = op.Nombre,
                                 Flete = op.FleteTotal,
                                 Empresa = op.Empresa,
                                 Honorarios = oc.Honorarios,
                                 NombreChofer = oc.Chofer
                             };
                return tuplas.ToList();
            }
            else
            {
                var tuplas = from op in Operaciones
                            join oc in OrdenesCarga
                            on op.IdOperacion equals oc.IdOperacion
                            where oc.Chofer == chofer && op.FleteTotal == flete && op.Empresa == empresa
                            select new OrdenCargaDTO
                            {
                                IdOperacion = op.IdOperacion,
                                IdOrdenCarga = oc.IdOrdenCarga,
                                Operacion = op.Nombre,
                                Flete = op.FleteTotal,
                                Empresa = op.Empresa,
                                Honorarios = oc.Honorarios,
                                NombreChofer = oc.Chofer
                            };
                return tuplas.ToList();
            }
        }
        static List<OrdenCargaDTO> ordenesdeCargaPorOperacion(int idOp,int cantidadElementos)
        {
            var tuplas = from op in Operaciones
                         join oc in OrdenesCarga
                             on op.IdOperacion equals oc.IdOperacion
                         where op.IdOperacion == idOp
                         select new OrdenCargaDTO
                         {
                             IdOperacion = op.IdOperacion,
                             IdOrdenCarga = oc.IdOrdenCarga,
                             Operacion = op.Nombre,
                             Flete = op.FleteTotal,
                             Empresa = op.Empresa,                             
                             Honorarios = oc.Honorarios,
                             NombreChofer = oc.Chofer
                         };
            return tuplas.Take(cantidadElementos).ToList();
           
        }
        static List<OrdenCargaDTO> listarOrdenesDeCargaConRelaciones()
        {

            /**
             * SELECT *
             * FROM Operacion op
             * INNER JOIN OrdenCarga oc
             * ON op.IdOperacion = oc.IdOperacion
             *
             */
            var tuplas = from op in Operaciones
                         join oc in OrdenesCarga
                             on op.IdOperacion equals oc.IdOperacion
                         select new OrdenCargaDTO
                         {
                             IdOperacion = op.IdOperacion,
                             Operacion = op.Nombre,
                             Flete = op.FleteTotal,
                             Empresa = op.Empresa,
                             IdOrdenCarga = oc.IdOrdenCarga,
                             Honorarios = oc.Honorarios,
                             NombreChofer = oc.Chofer
                         };

            return tuplas.ToList();
            //var t = tuplas.Select(x => x.FechaInicio).ToList();
        }

        // 1. Filtrar Los operaciones cuyo origen sea igual a LP ( Origen == "LP" y Destino == "SC")
        static List<Operacion> filtrarOperacionesPorOrigenYDestino(string origen, string destino)
        {
            return Operaciones.Where((op) => op.Origen == origen && op.Destino == destino).ToList();
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
        static void eliminarOperacionPorId(int ID)
        {
            Operacion operacionBuscada = Operaciones.FirstOrDefault(x => x.IdOperacion == ID);
            if (operacionBuscada != null)
            { // si existe
                Operaciones.RemoveAll(op => op.IdOperacion == ID);
                //Operaciones.Remove(operacionBuscada);
                Console.WriteLine("Eliminacion exitosa");
            }
            else
            {
                Console.WriteLine("La Operacion de ID =" + ID + " no existe en la base de datos");
            }
            //return Operaciones.Where((op) => op.Origen == ID || op.Destino == destino).ToList();
        }


        // 3. Ordenar las operaciones por Nombre de Empresa 


        // 4. Obtener la primera opearcion cuyo criterio XXX se cumpla



        public static void CargarBaseDeDatosInicial()
        {
            // listado de operaciones
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


            // listado de ordenes de carga
            OrdenesCarga.Add(new OrdenCarga
            {
                IdOrdenCarga = IdActualOrdenCarga++,
                FechaInicio = "01020",
                FechaFin = "01020",
                Chofer = "juan",
                Honorarios = 21313,
                IdOperacion = 1
            });

            OrdenesCarga.Add(new OrdenCarga
            {
                IdOrdenCarga = IdActualOrdenCarga++,
                FechaInicio = "057897",
                FechaFin = "979425",
                Chofer = "martin",
                Honorarios = 90000,
                IdOperacion = 1
            }); ;

        }
    }
}
