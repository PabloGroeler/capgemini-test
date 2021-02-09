using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capgemini_test.src.Core.Data.Context;
using capgemini_test.src.Core.Domain.Entities;
using capgemini_test.src.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace capgemini_test.src.Core.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private DbSet<ProdutoEntity> _dataset;
        public ProdutoRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<ProdutoEntity>();
        }

    }
}