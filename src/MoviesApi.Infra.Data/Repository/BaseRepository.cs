using Microsoft.EntityFrameworkCore;
using MoviesApi.Domain.Entities;
using MoviesApi.Domain.Interfaces.Repository;
using MoviesApi.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected internal async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                await _context.Set<T>().AddAsync(entity);
                await Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await GetByIdAsync(entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                    return false;

                _context.Set<T>().Remove(result);
                await Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
