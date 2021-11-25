using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01_Introduccion_Cognos
{
    public class OrdenCarga
    {
        public int IdOrdenCarga { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public double Honorarios { get; set; }
        public int IdOperacion { get; set; }
        public string Chofer { get; set; }

        public override string ToString() => $"Id: {IdOrdenCarga}, Chofer: {Chofer}, Fecha Inicio: {FechaInicio}, Fecha Fin: {FechaFin}, Honorarios: {Honorarios}, IdOperacion: {IdOperacion}";


    }
}
