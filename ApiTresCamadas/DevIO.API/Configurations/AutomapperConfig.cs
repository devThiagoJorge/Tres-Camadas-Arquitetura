using AutoMapper;
using DevIo.Domain.Models;
using DevIO.API.DTO;

namespace DevIO.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<ProdutoDto, Produto>();


            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.NomeFornecedor,
                opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}
