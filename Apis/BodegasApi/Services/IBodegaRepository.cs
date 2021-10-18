using BodegasApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasApi.Services
{
    public interface IBodegaRepository
    {
        IEnumerable<Bodega> GetBodegas();
    }
}
