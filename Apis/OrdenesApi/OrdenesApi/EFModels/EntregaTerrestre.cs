using System;
using System.Collections.Generic;

#nullable disable

namespace OrdenesApi.EFModels
{
    public partial class EntregaTerrestre
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

        public virtual Bodega Bodega { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
