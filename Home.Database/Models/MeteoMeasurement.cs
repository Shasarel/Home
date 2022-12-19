using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Database.Models
{
    [Table("meteo")]
    public class MeteoMeasurement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("time")]
        public DateTimeOffset DateTime { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        [Column("temperature")]
        public double Temperature { get; set; } = 0;

        [Required]
        [Column("humidity")]
        public double Humidity { get; set; } = 0;

        [Required]
        [Column("pressure")]
        public double Pressure { get; set; } = 0;

        [Required]
        [Column("dust_PM10")]
        public int DustPM10 { get; set; } = 0;

        [Required]
        [Column("dust_PM25")]
        public int DustPM25 { get; set; } = 0;

        [Required]
        [Column("dust_PM100")]
        public int DustPM100 { get; set; } = 0;

        [NotMapped]
        public bool IsDataCorrect { get; set; } = false;
    }
}
