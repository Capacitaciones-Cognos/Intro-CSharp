using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Operacion
    {
        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double FleteTotal { get; set; }
        public string Fecha { get; set; }
        public string Empresa { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

        public override string ToString()
        {
            return $"Id: {IdOperacion}, OPE: {Nombre}, Flete: {FleteTotal}, Fecha: {Fecha}, Empresa: {Empresa}, Origen: {Origen}, Destino: {Destino}";
        }

    }
}
