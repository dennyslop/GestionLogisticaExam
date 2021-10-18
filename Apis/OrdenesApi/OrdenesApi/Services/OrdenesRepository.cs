using OrdenesApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesApi.Services
{
    public class OrdenesRepository : IOrdenesRepository
    {
        private GestionLogisticaContext _context;

        public OrdenesRepository(GestionLogisticaContext context)
        {
            _context = context;
        }
        
        public EntregaMaritimo GetEntregaMaritimo(int id)
        {
            return _context.EntregaMaritimos.Where(c => c.EntregaId == id).FirstOrDefault(); 
        }

        public IEnumerable<EntregaMaritimo> GetEntregasMaritimo()
        {
            return _context.EntregaMaritimos.OrderBy(c => c.EntregaId).ToList();
        }

        public IEnumerable<EntregaTerrestre> GetEntregasTerrestre()
        {
            return _context.EntregaTerrestres.OrderBy(c => c.EntregaId).ToList();
        }

        public EntregaTerrestre GetEntregaTerrestre(int id)
        {
            return _context.EntregaTerrestres.Where(c => c.EntregaId == id).FirstOrDefault();
        }
        public void CrearOrdenesMaritimas(EntregaMaritimo ordenes)
        {
            var cliente = _context.Clientes.Where(x => x.ClienteId == ordenes.ClienteId).FirstOrDefault();
            if (cliente == null)
                return;

            var puerto = _context.Puertos.Where(x => x.PuertoId == ordenes.PuertoId).FirstOrDefault();
            if (puerto == null)
                return;

            _context.EntregaMaritimos.Add(ordenes);
        }

        public void CrearOrdenesTerrestres(EntregaTerrestre ordenes)
        {
            var cliente = _context.Clientes.Where(x => x.ClienteId == ordenes.ClienteId).FirstOrDefault();
            if (cliente == null)
                return;

            var bodega = _context.Bodegas.Where(x => x.BodegaId == ordenes.BodegaId).FirstOrDefault();
            if (bodega == null)
                return;
            
            _context.EntregaTerrestres.Add(ordenes);
        }

    }
}
