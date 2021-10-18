using ClientesApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Services
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetCliente(int clienteId);
        void CrearCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int clienteId);


    }
}
