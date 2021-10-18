using ClientesApi.EFModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Services
{
    public class ClienteRepository : IClienteRepository
    {
        private GestionLogisticaContext _context;

        public ClienteRepository(GestionLogisticaContext context)
        {
            _context = context;
        }
        public void ActualizarCliente(Cliente cliente)
        {
            var clase = _context.Clientes.Where(x => x.ClienteId == cliente.ClienteId).FirstOrDefault();
            if (clase != null)
            {
                clase.NombreCliente = cliente.NombreCliente;
                clase.DireccionCliente = cliente.DireccionCliente;
                clase.TelefonoCliente = cliente.TelefonoCliente;

                _context.SaveChanges();
            }
        }

        public void CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void EliminarCliente(int clienteId)
        {
            var clase = _context.Clientes.Where(x => x.ClienteId == clienteId).FirstOrDefault();
            if (clase != null)
            {
                _context.Clientes.Remove(clase);
                _context.SaveChanges();
            }
        }

        public Cliente GetCliente(int clienteId)
        {
            return _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.OrderBy(c => c.NombreCliente).ToList();
        }
    }
}
