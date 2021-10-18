using System;
using System.Collections.Generic;

#nullable disable

namespace OrdenesApi.EFModels
{
    public partial class Cliente
    {
        public Cliente()
        {
            EntregaMaritimos = new HashSet<EntregaMaritimo>();
            EntregaTerrestres = new HashSet<EntregaTerrestre>();
        }

        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }

        public virtual ICollection<EntregaMaritimo> EntregaMaritimos { get; set; }
        public virtual ICollection<EntregaTerrestre> EntregaTerrestres { get; set; }
    }
}
