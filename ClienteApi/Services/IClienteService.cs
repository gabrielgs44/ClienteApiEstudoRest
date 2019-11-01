using ClienteApi.Comum.Dto;
using ClienteApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public interface IClienteService
    {
        public Task<Cliente> CadastrarCliente(ClienteDto clienteDto);

        public Task<IEnumerable<Cliente>> ObterClientes(int? id);
        public Task<string> RemoverCliente(int? id);
        public Task<string> AtualizarCliente(ClienteDto clienteDto);
    }
}
