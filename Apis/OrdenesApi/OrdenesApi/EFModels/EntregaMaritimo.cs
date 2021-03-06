using System;
using System.Collections.Generic;

#nullable disable

namespace OrdenesApi.EFModels
{
    public partial class EntregaMaritimo
    {
        public int EntregaId { get; set; }
        public int? TipoProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? PuertoId { get; set; }
        public decimal? PrecioEnvio { get; set; }
        public string NumeroFlota { get; set; }
        public int? Descuento { get; set; }
        public string NumeroGuia { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Puerto Puerto { get; set; }
    }
}
