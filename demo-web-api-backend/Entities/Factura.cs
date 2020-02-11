using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo_web_api_backend.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public string FechaFactura { get; set; }
        public string Empresa { get; set; }
        public string MontoTotal { get; set; }
        public List<DetalleFactura> ListaDetalleFactura { get; set; }
    }
}
