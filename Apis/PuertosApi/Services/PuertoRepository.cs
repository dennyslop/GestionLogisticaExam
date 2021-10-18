using BodegasApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuertosApi.Services
{
    public class PuertoRepository : IPuertoRepository
    {
        private GestionLogisticaContext _context;

        public PuertoRepository(GestionLogisticaContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Puerto> GetPuertos()
        {
            return _context.Puertos.OrderBy(c => c.NombrePuerto).ToList();
        }
    }
}
