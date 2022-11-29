using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.WebApi.Database.Models
{
    public class MeteoMeasurement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required] 
        [Column("time")] 
        public DateTimeOffset DateTime { get; set; }

        [Required]
        [Column("temperature")]
        public double Temperature { get; set; }

        [Required]
        [Column("pressure")]
        public double Pressure { get; set; }

        [Required]
        [Column("dust_PM10")]
        public int DustPM10 { get; set; }

        [Required]
        [Column("dust_PM25")]
        public int DustPM25 { get; set; }

        [Required]
        [Column("dust_PM100")]
        public int DustPM100 { get; set; }

        [NotMapped] 
        public bool IsDataCorrect { get; set; }
    }
}
