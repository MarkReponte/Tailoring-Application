using AppDomain.Models;
using AppInfrastructure.Data;
using AppInfrastructure.IRepository;
using AppInfrastructure.Repository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Classes
{
    public class DashboardService
    {
        private readonly MeasurementRepository _measurementRepo;
        private readonly CostRepository _costRepo;

        public DashboardService(MeasurementRepository measurementRepo, CostRepository costRepo)
        {
            _measurementRepo = measurementRepo;
            _costRepo = costRepo;
        }

        public async Task<DashboardMetrics> GetMetricsAsync()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            List<Measurements> allMeasurements;
            List<MaterialCost> allCosts;

            using (var db = new SewingDbContext())
            {
                allMeasurements = await db.Measurements
                    .AsNoTracking()
                    .ToListAsync();
            }


            using (var costDb = new CostDBContext())
            {
                allCosts = await costDb.MaterialCosts
                    .AsNoTracking()
                    .ToListAsync();
            }

            int newCustomersCount = allMeasurements
                .Where(m => m.OrderDeadline >= startOfMonth && m.OrderDeadline <= endOfMonth)
                .Select(m => m.CustomerName)
                .Distinct()
                .Count();

            decimal totalMaterialCost = allCosts
                .Where(c => c.DateCreated >= startOfMonth && c.DateCreated <= endOfMonth)
                .Sum(c => c.MaterialTotal);

            decimal grossRevenue = allCosts
                .Where(c => c.DateCreated >= startOfMonth && c.DateCreated <= endOfMonth)
                .Sum(c => c.TotalLabor);

            return new DashboardMetrics
            {
                NewCustomer = newCustomersCount,
                TotalRevenue = grossRevenue,
                TotalCost = totalMaterialCost
            };
        }

        public async Task<List<DetailedReportRow>> GetDetailedReportAsync()
        {
            List<Measurements> allMeasurements;
            List<MaterialCost> allCosts;

            using (var db = new SewingDbContext())
            {
                allMeasurements = await db.Measurements.AsNoTracking().ToListAsync();
            }

            using (var costDb = new CostDBContext())
            {
                allCosts = await costDb.MaterialCosts.AsNoTracking().ToListAsync();
            }

            var aggregatedCost = allCosts
                .Where(c => !string.IsNullOrEmpty(c.CustomerNameCost))
                .GroupBy(c => c.CustomerNameCost)
                .ToDictionary(g => g.Key, g => g.Sum(c => c.GrandTotalCost));

            var reportData = allMeasurements.Select(m =>
                {
                    decimal totalCost = aggregatedCost.ContainsKey(m.CustomerName) ? aggregatedCost[m.CustomerName] : 0.00m;

                    return new DetailedReportRow
                    {
                        MeasurementId = m.Id,
                        CustomerName = m.CustomerName,
                        OrderValue = "₱" + totalCost.ToString("N2"),
                        OrderDeadline = m.OrderDeadline.ToString("MM/dd/yy"),
                        Status = m.Status
                    };
                }).OrderByDescending(row => DateTime.Parse(row.OrderDeadline)).ToList();

            return reportData;
        }
    } 


    public class DashboardMetrics
    {
        public int NewCustomer { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }

    }

    public class DetailedReportRow
    {
        public Guid MeasurementId { get; set; }
        public string CustomerName { get; set; }
        public string OrderValue { get; set; }  
        public string OrderDeadline { get; set; } 
        public string Status { get; set; }
    }
}
