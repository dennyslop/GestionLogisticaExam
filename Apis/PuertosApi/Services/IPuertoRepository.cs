using BodegasApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuertosApi.Services
{
    public interface IPuertoRepository
    {
        IEnumerable<Puerto> GetPuertos();
    }
}
