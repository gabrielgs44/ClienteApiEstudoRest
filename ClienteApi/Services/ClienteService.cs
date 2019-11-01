using AutoMapper;
using ClienteApi.Comum.Dto;
using ClienteApi.Comum.Exceptions;
using ClienteApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteApiContext _context;

        public ClienteService(ClienteApiContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CadastrarCliente(ClienteDto clienteDto)
        {
            var cliente = Cliente.Criar(clienteDto.Id, clienteDto.Nome, clienteDto.Login, clienteDto.Senha);
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> ObterClientes(int? id)
        {
            if (id.HasValue)
            {
                return new List<Cliente>() { await _context.FindAsync<Cliente>(id.Value) };
            }
            else
            {
                return _context.Cliente.ToList();
            }
        }

        public async Task<string> RemoverCliente(int? id)
        {
            if (id.HasValue)
            {
                var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id.Value);

                if (cliente != null)
                {
                    _context.Remove(cliente);
                    await _context.SaveChangesAsync();
                    return "Cliente removido!";
                }
                else
                {
                    throw new NaoEncontradoException("Cliente não encontrado!");
                }
            }

            throw new NaoEncontradoException("Cliente não encontrado!");
        }

        public async Task<string> AtualizarCliente(ClienteDto clienteDto)
        {
            if (!_context.Cliente.Any(x => x.Id == clienteDto.Id))
            {
                throw new NaoEncontradoException("Id não foi encontrado!");
            }
            else
            {

                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ClientePerfil());
                });
                var mapper = new Mapper(mapperConfig);

                var cliente = mapper.Map<Cliente>(clienteDto);
                _context.Cliente.Update(cliente);
                await _context.SaveChangesAsync();
                return "Atualizado!";
            }
        }
    }
}
