using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBD.DbModels
{
    [Table("meteo_daily")]
    public class DailyMeteoSummary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("day_ordinal")]
        public int Date { get; set; }

        [Required]
        [Column("temperature_min")]
        public double TemperatureMin { get; set; }

        [Required]
        [Column("temperature_avg")]
        public double TemperatureAvg { get; set; }

        [Required]
        [Column("temperature_max")]
        public double TemperatureMax { get; set; }

        [Required]
        [Column("humidity_min")]
        public double HumidityMin { get; set; }

        [Required]
        [Column("humidity_avg")]
        public double HumidityAvg { get; set; }

        [Required]
        [Column("humidity_max")]
        public double HumidityMax { get; set; }

        [Required]
        [Column("pressure_min")]
        public double PressureMin { get; set; }

        [Required]
        [Column("pressure_avg")]
        public double PressureAvg { get; set; }

        [Required]
        [Column("pressure_max")]
        public double PressureMax { get; set; }

        [Required]
        [Column("dust_PM10_min")]
        public int DustPM10Min { get; set; }

        [Required]
        [Column("dust_PM10_avg")]
        public int DustPM10Avg { get; set; }

        [Required]
        [Column("dust_PM10_max")]
        public int DustPM10Max { get; set; }

        [Required]
        [Column("dust_PM25_min")]
        public int DustPM25Min { get; set; }

        [Required]
        [Column("dust_PM25_avg")]
        public int DustPM25Avg { get; set; }

        [Required]
        [Column("dust_PM25_max")]
        public int DustPM25Max { get; set; }

        [Required]
        [Column("dust_PM100_min")]
        public int DustPM100Min { get; set; }

        [Required]
        [Column("dust_PM100_avg")]
        public int DustPM100Avg { get; set; }

        [Required]
        [Column("dust_PM100_max")]
        public int DustPM100Max { get; set; }

        [Required]
        [Column("is_data_correct")]
        public bool IsDataCorrect { get; set; }


    }
}
