using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_web_api_backend.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string Empresa { get; set; }
        public double Precio { get; set; }
    }
}
