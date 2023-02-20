﻿using HellsShop.Application.Models;
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
    internal class PriceRepository : IPriceRepository
    {
        private readonly DatabaseContext _context;

        public PriceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Price entity)
        {
            _context.Prices.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Price> GetAsync(long? id)
        {
            return _context.Prices.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Price>> GetAsync()
        {
            return await _context.Prices.AsQueryable()
                .ToListAsync();
        }

        public async Task<Price> GetByProductAsync(long? productId)
        {
            return await _context.Prices.AsQueryable()
                .Where(e => e.Product.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<long?> SaveAsync(Price entity)
        {
            await _context.Prices.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Price entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
