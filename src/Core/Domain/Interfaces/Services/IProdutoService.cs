using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Entities;

namespace capgemini_test.src.Core.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDtoGet> Get(Guid id);
        Task<IEnumerable<ProdutoDtoGet>> GetAll();
        Task<IEnumerable<ProdutoDtoGet>> Post(List<ProdutoDtoPost> produtos);
    }
}