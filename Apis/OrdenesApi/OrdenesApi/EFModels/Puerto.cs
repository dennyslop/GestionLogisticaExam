using System;
using System.Collections.Generic;

#nullable disable

namespace OrdenesApi.EFModels
{
    public partial class Puerto
    {
        public Puerto()
        {
            EntregaMaritimos = new HashSet<EntregaMaritimo>();
        }

        public int PuertoId { get; set; }
        public string CodPuerto { get; set; }
        public string NombrePuerto { get; set; }

        public virtual ICollection<EntregaMaritimo> EntregaMaritimos { get; set; }
    }
}
