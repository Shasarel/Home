using Home.Database.Enums.Blinds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Action = Home.Database.Enums.Blinds.Action;
using TaskStatus = Home.Database.Enums.Blinds.TaskStatus;

namespace Home.Database.Models
{
    [Table("blinds_task")]
    public class BlindTask
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("time")] 
        public DateTimeOffset DateTime { get; set; }

        [Required]
        [Column("device")] 
        public Device Device { get; set; }

        [Required]
        [Column("action")] 
        public Action Action { get; set; }

        [Column("user_id")] 
        public int? User { get; set; }

        [Column("schedule_id")]
        public int? BlindsSchedule { get; set; }

        [Required]
        [Column("timeout")]
        public int Timeout { get; set; }

        [Required]
        [Column("active")]
        public TaskStatus Status { get; set; }
    }
}
