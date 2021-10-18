using System;
using System.Collections.Generic;

#nullable disable

namespace OrdenesApi.EFModels
{
    public partial class Bodega
    {
        public Bodega()
        {
            EntregaTerrestres = new HashSet<EntregaTerrestre>();
        }

        public int BodegaId { get; set; }
        public string CodBodega { get; set; }
        public string NombreBodega { get; set; }

        public virtual ICollection<EntregaTerrestre> EntregaTerrestres { get; set; }
    }
}
