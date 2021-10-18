using BodegasApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasApi.Services
{
    public class BodegaRepository : IBodegaRepository
    {
        private GestionLogisticaContext _context;

        public BodegaRepository(GestionLogisticaContext context)
        {
            _context = context;
        }
        public IEnumerable<Bodega> GetBodegas()
        {
            return _context.Bodegas.OrderBy(c => c.NombreBodega).ToList();
        }
    }
}
