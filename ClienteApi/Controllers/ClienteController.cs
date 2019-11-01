﻿using ClienteApi.Comum.Dto;
using ClienteApi.Comum.Exceptions;
using ClienteApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ClienteApi.Comum
{
    [Route("api/clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("CadastrarCliente")]
        public IActionResult CadastrarCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                var clienteCriado = _clienteService.CadastrarCliente(cliente);
                return Created("Cliente/" + clienteCriado.Id, clienteCriado);

            }
            catch (Exception e)
            {
                return StatusCode(500, new ErroDto() { mensagens = new List<String>() { e.Message } });
            }
        }

        [HttpGet]
        [Route("Cliente")]
        public IActionResult ObterCliente(int? id)
        {
            try
            {
                return Ok(_clienteService.ObterClientes(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("Cliente")]
        public IActionResult DeletarCliente(int? id)
        {
            try
            {
                var mensagem = _clienteService.RemoverCliente(id);
                return Ok(mensagem);

            }
            catch (NaoEncontradoException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErroDto() { mensagens = new List<String>() { e.Message } });
            }
        }

        [HttpPut]
        [Route("AtualizarCliente")]
        public IActionResult AtualizarCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var mensagem = _clienteService.AtualizarCliente(clienteDto);
                return Ok(mensagem);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErroDto() { mensagens = new List<string>() { e.Message } });
            }
        }
    }
}