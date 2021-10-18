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
    [Route("api/ordenesmaritimas")]
    [ApiController]
    [Authorize]
    public class OrdenesMaritimasController : Controller
    {
        private IOrdenesRepository _ordeneRepository;

        public OrdenesMaritimasController(IOrdenesRepository ordeneRepository)
        {
            //se crea constructor para pasar por inyecion de dependencia el repository  
            _ordeneRepository = ordeneRepository;
        }

        [HttpGet()]
        public IActionResult GetOrdenesMaritimas()
        {
            //metodo para obtener la lista de ordenes maritimas
            var ordenes = _ordeneRepository.GetEntregasMaritimo();
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<IEnumerable<OrdenesMaritimasDTO>>(ordenes);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CrearOrdenesMaritimas(OrdenesMaritimasDTO ordenes)
        {
            if (ordenes == null)
                return NoContent();

            if (ordenes.NumeroFlota.Length < 6 || ordenes.NumeroFlota.Length > 6)
                return NoContent();

            string pattern = @"([A-Z]{3})+([0-9]{3})+";
            Match m = Regex.Match(ordenes.NumeroFlota, pattern, RegexOptions.IgnoreCase);
            if (!m.Success)
                return NoContent();
            
            if (ordenes.NumeroGuia.Length < 10 || ordenes.NumeroGuia.Length > 10)
                return NoContent();

            if (ordenes.CantidadProducto > 10)
                ordenes.Descuento = 5;
            else
                ordenes.Descuento = 0;

            var result = Mapper.Map<EntregaMaritimo>(ordenes);
            _ordeneRepository.CrearOrdenesMaritimas(result);

            return Ok();
        }
    }
}
