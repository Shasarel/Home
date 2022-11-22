using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.WebApi.Models
{
    [Table("energy_daily")]
    public class DailyElectricitySummary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("day_ordinal")]
        public int Date { get; set; }

        [Required]
        [Column("production")]
        public double EnergyProduction { get; set; }

        [Required]
        [Column("production_deye")]
        public double EnergyProductionDeye { get; set; }

        [Required]
        [Column("import")]
        public double EnergyImport { get; set; }

        [Required]
        [Column("export")]
        public double EnergyExport { get; set; }

        [Required]
        [Column("production_offset")]
        public double EnergyProductionSum { get; set; }

        [Required]
        [Column("production_deye_offset")]
        public double EnergyProductionSumDeye { get; set; }

        [Required]
        [Column("import_offset")]
        public double EnergyImportSum { get; set; }

        [Required]
        [Column("export_offset")]
        public double EnergyExportSum { get; set; }

        [Required]
        [Column("max_power_production")]
        public int MaxPowerProduction { get; set; }

        [Required]
        [Column("max_power_import")]
        public int MaxPowerImport { get; set; }

        [Required]
        [Column("max_power_export")]
        public int MaxPowerExport { get; set; }

        [Required] 
        [Column("max_power_consumption")]
        public int MaxPowerConsumption { get; set; }

        [Required]
        [Column("max_power_use")]
        public int MaxPowerUse { get; set; }

        [Required]
        [Column("max_power_store")]
        public int MaxPowerStore { get; set; }

    }
}
