using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capgemini_test.src.Core.Data.Context;
using capgemini_test.src.Core.Domain.Entities;
using capgemini_test.src.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace capgemini_test.src.Core.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error on Delete", e);
            }
        }

        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> itens)
        {
            try
            {
                foreach(T item in itens) {
                    if (item.Id == Guid.Empty)
                    {
                        item.Id = Guid.NewGuid();
                    }

                _dataset.Add(item);

                }
                
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Insert", e);
            }

            return itens;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw new Exception("Error on Exist", e);
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Select", e);
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Update", e);
            }

            return item;
        }
    }
}