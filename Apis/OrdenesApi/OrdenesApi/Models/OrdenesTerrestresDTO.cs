using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesApi.Models
{
    public class OrdenesTerrestresDTO
    {
        public int EntregaId { get; set; }
        public int? TipoProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? BodegaId { get; set; }
        public decimal? PrecioEnvio { get; set; }
        public string PlacaVehiculo { get; set; }
        public int? Descuento { get; set; }
        public string NumeroGuia { get; set; }
        public int ClienteId { get; set; }
    }
}
