using System.Collections.Generic;

namespace Seguros.Api.Modelos
{
    public class Asegurados
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public int edad { get; set; }
    }
}
