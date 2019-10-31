using ClienteApi.Comum.Dto;
using ClienteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public interface IClienteService
    {
        public Cliente CadastrarCliente(ClienteDto clienteDto);

        public IEnumerable<Cliente> ObterClientes(int? id);
        public string RemoverCliente(int? id);
        public string AtualizarCliente(ClienteDto clienteDto);
    }
}
