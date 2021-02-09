using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Entities;
using capgemini_test.src.Core.Domain.Interfaces.Repositories;
using capgemini_test.src.Core.Domain.Interfaces.Services;
using capgemini_test.src.Core.Domain.Models;

namespace capgemini_test.src.Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProdutoDtoGet> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ProdutoDtoGet>(entity);
        }

        public async Task<IEnumerable<ProdutoDtoGet>> GetAll()
        {
            var entity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ProdutoDtoGet>>(entity);
        }

        public async Task<IEnumerable<ProdutoDtoGet>> Post(List<ProdutoDtoPost> produtos)
        {
            List<ProdutoEntity> produtosEntities = _mapper.Map<List<ProdutoEntity>>(produtos);

            List<ProdutoDtoGet> results = new List<ProdutoDtoGet>();
            
            // foreach (ProdutoEntity entity in produtosEntities) {
                results.Add(_mapper.Map<ProdutoDtoGet>(await _repository.InsertAsync(produtosEntities)));
            // }

            return results;
        }
    }
}