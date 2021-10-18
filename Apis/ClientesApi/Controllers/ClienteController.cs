using AutoMapper;
using ClientesApi.Models;
using ClientesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using ClientesApi.EFModels;

namespace ClientesApi.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            //se crea constructor para pasar por inyecion de dependencia el repository
            _clienteRepository = clienteRepository;
        }

        [HttpGet()]
        public IActionResult GetClientes()
        {
            //metodo para obtener la lista de clientes
            var clientes = _clienteRepository.GetClientes();
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<IEnumerable<ClientesDTO>>(clientes);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var clientes = _clienteRepository.GetCliente(id);
            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<ClientesDTO>(clientes);

            //se realiza validacionsi trae registros desde el repository 
            if (result == null)
                return NotFound();
            //en caso de traer registros se retorna el dto
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CrearClientes(ClientesDTO clientes)
        {
            //metodo para crear clientes
            //sevalida si eldto llega null
            if (clientes == null)
                return NoContent();

            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<Cliente>(clientes);
            _clienteRepository.CrearCliente(result);

            return Ok();
        }

        [HttpPut]
        public IActionResult ActualizarClientes(ClientesDTO clientes)
        {
            //metodo para actualizar clientes
            //sevalida si eldto llega null
            if (clientes == null)
                return NoContent();

            //se crea mapper para trabajar con una clase dto y no trabajar con la que viene del entity
            var result = Mapper.Map<Cliente>(clientes);
            _clienteRepository.ActualizarCliente(result);

            return Ok();
        }

        [HttpDelete]
        public IActionResult EliminarClientes(int id)
        {
            //metodo para eliminar clientes

            _clienteRepository.EliminarCliente(id);

            return Ok();
        }


    }
}
