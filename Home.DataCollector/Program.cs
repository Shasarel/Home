using Home.MeasurementFetcher;
using Home.WebApi.Database;

var data = await MeasurementFetcher.GetAllMeasurements();

using var context = new HomeContext();

context.Add(data.MeteoMeasurement);
context.Add(data.ElectricityMeasurement);
context.SaveChanges();