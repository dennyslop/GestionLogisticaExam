using System;
using System.Collections.Generic;

#nullable disable

namespace ClientesApi.EFModels
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
    }
}
