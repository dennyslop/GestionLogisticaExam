using System;
using System.Collections.Generic;

#nullable disable

namespace BodegasApi.EFModels
{
    public partial class Bodega
    {
        public int BodegaId { get; set; }
        public string CodBodega { get; set; }
        public string NombreBodega { get; set; }
    }
}
