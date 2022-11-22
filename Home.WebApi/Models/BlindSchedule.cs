using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Home.WebApi.Enums.Blinds;
using Action = Home.WebApi.Enums.Blinds.Action;

namespace Home.WebApi.Models
{
    [Table("blinds_schedule")]
    public class BlindSchedule
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }

        [Required]
        [Column("device")] 
        public Device Device { get; set; }

        [Required]
        [Column("action")] 
        public Action Action { get; set; }

        [Required]
        [Column("hour_type")] 
        public HourType HourType { get; set; }

        [Required]
        [Column("time_offset")] 
        public int TimeOffset { get; set; }

        [Required]
        [Column("user_id")] 
        public int User { get; set; }
    }
}
