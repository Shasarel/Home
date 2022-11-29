using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Home.WebApi.Enums.Blinds;
using Action = Home.WebApi.Enums.Blinds.Action;
using TaskStatus = Home.WebApi.Enums.Blinds.TaskStatus;

namespace Home.WebApi.Database.Models
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
        public int User { get; set; }

        [Column("schedule_id")]
        public int BlindsSchedule { get; set; }

        [Required]
        [Column("timeout")]
        public int Timeout { get; set; }

        [Required]
        [Column("active")]
        public TaskStatus Status { get; set; }
    }
}
