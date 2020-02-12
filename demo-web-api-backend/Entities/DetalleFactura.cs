using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_web_api_backend.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Monto { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
