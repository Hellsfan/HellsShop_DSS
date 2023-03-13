using HellsShop.Application.Models;
using HellsShop.Application.Services.Interfaces;
using HellsShop.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsShop.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Task DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Category> GetAsync(long? id)
        {
            return _context.Categories.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.AsQueryable()
                .ToListAsync();
        }

        public async Task<Category> GetByProductAsync(Product product)
        {
            return await _context.Categories.AsQueryable()
                .Where(e => e.Products == product)
                .FirstOrDefaultAsync();
        }

        public async Task<long?> SaveAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
