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

        public IQueryable<MaterialCost> GetQueryable()
        {
            return _context.MaterialCosts.AsNoTracking();
        }

        public async Task DeleteAllCompletedCostsAsync(List<string> completedCustomerNames)
        {
            var recordsToDelete = await _context.MaterialCosts
                .Where(c => completedCustomerNames.Contains(c.CustomerNameCost))
                .ToListAsync();

            if (recordsToDelete.Any())
            {
                _context.MaterialCosts.RemoveRange(recordsToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
