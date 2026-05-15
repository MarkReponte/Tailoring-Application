using AppDomain.Models;
using AppInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AppInfrastructure.Repository
{
    public class CostRepository
    {
        private readonly CostDBContext _context;

        public CostRepository(CostDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaterialCost>> GetAllAsync() =>
            await _context.MaterialCosts.Include(c  => c.Items).ToListAsync();

        public async Task AddAsync(MaterialCost entity) =>
            await _context.MaterialCosts.AddAsync(entity);

        public async Task UpdateAsync(MaterialCost entity) =>
            _context.MaterialCosts.Update(entity);

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
