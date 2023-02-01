using AutoMapper;
using CadastroCliente.DTO;
using CadastroCliente.Entites;

namespace CadastroCliente.AutoMapper
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Contato, ContatoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
