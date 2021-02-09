using AutoMapper;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Models;

namespace capgemini_test.src.Core.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Produto
                CreateMap<ProdutoModel, ProdutoDtoGet>().ReverseMap();
            #endregion
        }
    }
}