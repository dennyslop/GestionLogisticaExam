using AutoMapper;
using BodegasApi.Models;
using BodegasApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasApi.Controllers
{
    [Route("api/bodegas")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private IBodegaRepository _bodegaRepository;

        public BodegaController(IBodegaRepository bodegaRepository)
        {
            //se crea constructor para pasar por inyecion de dependencia el repository
            _bodegaRepository = bodegaRepository;
        }

        [HttpGet()]
        public IActionResult GetClientes()
        {
            //metodo para obtener la lista de bodegas
            var clientes = _bodegaRepository.GetBodegas();
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<IEnumerable<BodegasDTO>>(clientes);

            return Ok(result);
        }
    }
}
