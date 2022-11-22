using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.WebApi.Models
{
    [Table("energy_corrections")]
    public class EnergyCorrection
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public string? Date { get; set; }

        [Required]
        [Column("correction")]
        public double Correction { get; set; }
    }
}
