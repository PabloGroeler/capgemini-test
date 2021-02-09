using AutoMapper;
using capgemini_test.src.Core.Domain.Entities;
using capgemini_test.src.Core.Domain.Models;

namespace capgemini_test.src.Core.CrossCutting.Mappings
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ProdutoEntity, ProdutoModel>().ReverseMap();        
        }
    }
}