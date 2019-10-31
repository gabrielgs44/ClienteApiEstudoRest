using AutoMapper;
using ClienteApi.Comum.Dto;
using ClienteApi.Models;

namespace ClienteApi.Services
{
    public class ClientePerfil : Profile
    {
        public ClientePerfil() => CreateMap<ClienteDto, Cliente>();
    }
}
