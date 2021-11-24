using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01_Introduccion_Cognos
{
    public class OrdenCarga
    {
        public int IdOrdenCarga { get; internal set; }
        public string FechaInicio { get; internal set; }
        public string FechaFin { get; internal set; }
        public double Honorarios { get; internal set; }
        public int IdOperacion { get; internal set; }
        public string Chofer { get; internal set; }

        public override string ToString()
        {
            return $"Id: {IdOrdenCarga}, Chofer: {Chofer} Fecha Inicio: {FechaInicio}, Fecha Fin: {FechaFin}, Honorarios: {Honorarios}";
        }

    }
}
