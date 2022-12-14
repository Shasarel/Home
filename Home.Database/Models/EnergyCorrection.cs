using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Database.Models
{
    [Table("energy_corrections")]
    public class EnergyCorrection
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateTimeOffset Date { get; set; }

        [Required]
        [Column("correction")]
        public double Correction { get; set; }
    }
}
