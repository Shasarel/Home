using Home.Database.Enums.Blinds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Action = Home.Database.Enums.Blinds.Action;

namespace Home.Database.Models
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
