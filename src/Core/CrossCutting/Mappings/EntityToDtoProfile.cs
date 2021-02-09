using AutoMapper;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Entities;

namespace capgemini_test.src.Core.CrossCutting.Mappings
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ProdutoEntity, ProdutoDtoGet>().ReverseMap();
            CreateMap<ProdutoEntity, ProdutoDtoPost>().ReverseMap();        
        }
    }
}