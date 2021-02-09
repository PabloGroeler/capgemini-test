
using capgemini_test.src.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace capgemini_test.src.Core.Data.Context
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<ProdutoEntity> Produtos { get; set; }
    }
}