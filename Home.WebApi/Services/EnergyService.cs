﻿using Home.WebApi.Database;
using Home.WebApi.Database.Models;
using Home.WebApi.DTOs;
using Home.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Home.WebApi.Services
{
    public class EnergyService : IEnergyService
    {
        private readonly HomeContext _context;

        public EnergyService(HomeContext context)
        {
            _context = context;
        }

        public EnergyDto GetEnergyData(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var fromMeasurement = _context.ElectricityMeasurement
                .Where(x => x.DateTime >= fromDate && x.DateTime < toDate)
                .FirstOrDefault();

            var toMeasurement = _context.ElectricityMeasurement
                .Where(x => x.DateTime > fromDate && x.DateTime <= toDate)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            toMeasurement ??= new ElectricityMeasurement();
            fromMeasurement ??= new ElectricityMeasurement();

            if (fromMeasurement.Id == 1)
                fromMeasurement = new ElectricityMeasurement();

            return new EnergyDto
            {
                Production = Math.Round(toMeasurement.EnergyProductionAll - fromMeasurement.EnergyProductionAll, 2),
                Import = Math.Round(toMeasurement.EnergyImport - fromMeasurement.EnergyImport, 2),
                Export = Math.Round(toMeasurement.EnergyExport - fromMeasurement.EnergyExport, 2),
                Use = Math.Round(toMeasurement.EnergyUse - fromMeasurement.EnergyUse, 2),
                Consumption = Math.Round(toMeasurement.EnergyConsumption - fromMeasurement.EnergyConsumption, 2),
                Store = Math.Round(toMeasurement.EnergyStore - fromMeasurement.EnergyStore, 2),
            };
        }
    }
}