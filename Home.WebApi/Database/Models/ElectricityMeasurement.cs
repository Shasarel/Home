using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.WebApi.Database.Models
{
    [Table("energy")]
    public class ElectricityMeasurement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("time")]
        public DateTimeOffset DateTime { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        [Column("production")]
        public double EnergyProduction { get; set; } = 0;

        [Required]
        [Column("production_deye")]
        public double EnergyProductionDeye { get; set; } = 0;

        [Required]
        [Column("import")]
        public double EnergyImport { get; set; } = 0;

        [Required]
        [Column("export")]
        public double EnergyExport { get; set; } = 0;

        [Required]
        [Column("power_production")]
        public int PowerProduction { get; set; } = 0;

        [Required]
        [Column("power_production_deye")]
        public int PowerProductionDeye { get; set; } = 0;

        [Required]
        [Column("power_import")]
        public int PowerImport { get; set; } = 0;

        [Required]
        [Column("power_export")]
        public int PowerExport { get; set; } = 0;

        [NotMapped]
        public double EnergyConsumption => EnergyUse + EnergyImport;

        [NotMapped]
        public double EnergyUse => EnergyProductionAll - EnergyExport;

        [NotMapped]
        public double EnergyStore => EnergyExport * 0.8 - EnergyImport;

        [NotMapped]
        public double EnergyProductionAll => EnergyProduction + EnergyProductionDeye;

        [NotMapped]
        public bool Correct { get; set; } = false;
    }
}
