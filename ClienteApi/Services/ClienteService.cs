using ClienteApi.Comum.Dto;
using ClienteApi.Models;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ClienteApi.Comum.Exceptions;

namespace ClienteApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteApiContext _context;

        public ClienteService(ClienteApiContext context)
        {
            _context = context;
        }

        public Cliente CadastrarCliente(ClienteDto clienteDto)
        {
            var cliente = Cliente.Criar(clienteDto.Id, clienteDto.Nome, clienteDto.Login, clienteDto.Senha);
            _context.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public IEnumerable<Cliente> ObterClientes(int? id)
        {
            if (id.HasValue)
            {
                return new List<Cliente>() { _context.Find<Cliente>(id.Value) };
            }
            else
            {
                return _context.Cliente.ToList();
            }
        }

        public string RemoverCliente(int? id)
        {
            if (id.HasValue)
            {
                var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id.Value);

                if (cliente != null)
                {
                    _context.Remove(cliente);
                    _context.SaveChanges();
                    return "Cliente removido!";
                }
                else
                {
                    throw new NaoEncontradoException("Cliente não encontrado!");
                }
            }

            throw new NaoEncontradoException("Cliente não encontrado!");
        }

        public string AtualizarCliente(ClienteDto clienteDto)
        {
            if(!_context.Cliente.Any(x => x.Id == clienteDto.Id))
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
                _context.SaveChanges();
                return "Atualizado!";
            }
        }
    }
}
