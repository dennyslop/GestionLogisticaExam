using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdenesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesApi.Models;
using OrdenesApi.EFModels;
using System.Text.RegularExpressions;

namespace OrdenesApi.Controllers
{
    [Route("api/ordenesterrestres")]
    [ApiController]
    [Authorize]
    public class OrdenesTerrestresController : Controller
    {
        private IOrdenesRepository _ordeneRepository;

        public OrdenesTerrestresController(IOrdenesRepository ordeneRepository)
        {
            //se crea constructor para pasar por inyecion de dependencia el repository
            _ordeneRepository = ordeneRepository;
        }

        [HttpGet()]
        public IActionResult GetOrdenesTerrestre()
        {
            //metodo para obtener la lista de ordenes terrestres
            var ordenes = _ordeneRepository.GetEntregasTerrestre();
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<IEnumerable<OrdenesTerrestresDTO>>(ordenes);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CrearOrdenesTerrestres(OrdenesTerrestresDTO ordenes)
        {

            if (ordenes == null)
                return NoContent();

            if (ordenes.PlacaVehiculo.Length < 6 || ordenes.PlacaVehiculo.Length > 6)
                return NoContent();

            string pattern = @"([A-Z]{3})+([0-9]{3})+";
            Match m = Regex.Match(ordenes.PlacaVehiculo, pattern, RegexOptions.IgnoreCase);
            if (!m.Success)
                return NoContent();

            if (ordenes.NumeroGuia.Length < 10 || ordenes.NumeroGuia.Length > 10)
                return NoContent();

            if (ordenes.CantidadProducto > 10)
                ordenes.Descuento = 3;
            else
                ordenes.Descuento = 0;

            var result = Mapper.Map<EntregaMaritimo>(ordenes);
            _ordeneRepository.CrearOrdenesMaritimas(result);

            return Ok();
        }

    }
}
