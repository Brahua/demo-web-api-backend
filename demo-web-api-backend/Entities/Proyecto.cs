using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo_web_api_backend.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }
        [Required]
        public string NombreProyecto { get; set; }
        [Required]
        public string Empresa { get; set; }
        public double Precio { get; set; }
    }
}
