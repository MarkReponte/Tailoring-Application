using AppDomain.Models;
using AppInfrastructure.Data;
using AppInfrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfrastructure.Repository
{
    public class MeasurementRepository : IRepository<Measurements>
    {
        private readonly SewingDbContext _context;

        public MeasurementRepository(SewingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measurements>> GetAllAsync() =>
         await _context.Measurements.ToListAsync();

        public async Task<IEnumerable<Measurements>> GetActiveOrdersAsync() =>
            await _context.Measurements.Where(m => m.Status != "Completed").ToListAsync();

        public async Task<IEnumerable<Measurements>> GetCompletedOrdersAsync() =>
            await _context.Measurements.Where(m => m.Status == "Completed").ToListAsync();

        public async Task AddAsync(Measurements entity) => await _context.Measurements.AddAsync(entity);

        public async Task UpdateAsync(Measurements entity)
        {
            _context.Measurements.Update(entity);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}

