using AutoMapper;
using PuertosApi.Models;
using PuertosApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuertosApi.Controllers
{
    [Route("api/puertos")]
    [ApiController]
    public class PuertoController : ControllerBase
    {
        private IPuertoRepository _puertoRepository;

        public PuertoController(IPuertoRepository puertoRepository)
        {
            //se crea constructor para pasar por inyecion de dependencia el repository
            _puertoRepository = puertoRepository;
        }

        [HttpGet()]
        public IActionResult GetClientes()
        {
            //metodo para obtener la lista de puertos
            var clientes = _puertoRepository.GetPuertos();
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<IEnumerable<PuertosDTO>>(clientes);

            return Ok(result);
        }
    }
}
