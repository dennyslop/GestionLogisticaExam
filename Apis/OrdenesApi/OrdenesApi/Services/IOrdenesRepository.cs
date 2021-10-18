using OrdenesApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesApi.Services
{
    public interface IOrdenesRepository
    {
        IEnumerable<EntregaMaritimo> GetEntregasMaritimo();
        IEnumerable<EntregaTerrestre> GetEntregasTerrestre();
        EntregaMaritimo GetEntregaMaritimo(int id);
        EntregaTerrestre GetEntregaTerrestre(int id);
        void CrearOrdenesMaritimas(EntregaMaritimo ordenes);
        void CrearOrdenesTerrestres(EntregaTerrestre ordenes);
    }
}
