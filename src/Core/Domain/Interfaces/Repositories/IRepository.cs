using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capgemini_test.src.Core.Domain.Entities;

namespace capgemini_test.src.Core.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T itens);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> itens);
    }
}