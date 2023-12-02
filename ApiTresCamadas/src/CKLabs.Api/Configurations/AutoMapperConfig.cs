using AutoMapper;
using CKLabs.Api.DTO;
using CKLabs.Business.Models;

namespace CKLabs.Api.Configurations
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.NomeFornecedor,
                opt => opt.MapFrom(src => src.Fornecedor == null ? string.Empty : src.Fornecedor.Nome));
        }
    }
}
