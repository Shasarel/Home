using Home.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.WebApi.Database.Models
{
    [Table("energy_daily")]
    public class DailyElectricitySummary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("day_ordinal")]
        public DateTimeOffset Date { get; set; }

        [Required]
        [Column("production")]
        public double EnergyProductionDaily { get; set; } = 0;

        [Required]
        [Column("production_deye")]
        public double EnergyProductionDeyeDaily { get; set; } = 0;

        [Required]
        [Column("import")]
        public double EnergyImportDaily { get; set; } = 0;

        [Required]
        [Column("export")]
        public double EnergyExportDaily { get; set; } = 0;

        [Required]
        [Column("production_offset")]
        public double EnergyProductionTotal { get; set; } = 0;

        [Required]
        [Column("production_deye_offset")]
        public double EnergyProductionDeyeTotal { get; set; } = 0;

        [Required]
        [Column("import_offset")]
        public double EnergyImportTotal { get; set; } = 0;

        [Required]
        [Column("export_offset")]
        public double EnergyExportTotal { get; set; } = 0;

        [Required]
        [Column("max_power_production")]
        public int MaxPowerProduction { get; set; } = 0;

        [Required]
        [Column("max_power_import")]
        public int MaxPowerImport { get; set; } = 0;

        [Required]
        [Column("max_power_export")]
        public int MaxPowerExport { get; set; } = 0;

        [Required] 
        [Column("max_power_consumption")]
        public int MaxPowerConsumption { get; set; } = 0;

        [Required]
        [Column("max_power_use")]
        public int MaxPowerUse { get; set; } = 0;

        [Required]
        [Column("max_power_store")]
        public int MaxPowerStore { get; set; } = 0;

        [NotMapped]
        public double EnergyConsumption => EnergyUse + EnergyImportDaily;

        [NotMapped]
        public double EnergyUse => EnergyProductionAll - EnergyExportDaily;

        [NotMapped]
        public double EnergyStore => EnergyExportDaily * HomeConfig.Default.EnergyReturnFactor - EnergyImportDaily;

        [NotMapped]
        public double EnergyProductionAll => EnergyProductionDaily + EnergyProductionDeyeDaily;


        [NotMapped]
        public double EnergyConsumptionTotal => EnergyUseTotal + EnergyImportTotal;

        [NotMapped]
        public double EnergyUseTotal => EnergyProductionTotalAll - EnergyExportTotal;

        [NotMapped]
        public double EnergyStoreTotal => EnergyExportTotal * HomeConfig.Default.EnergyReturnFactor - EnergyImportTotal;

        [NotMapped]
        public double EnergyProductionTotalAll => EnergyProductionTotal + EnergyProductionDeyeTotal;

    }
}
