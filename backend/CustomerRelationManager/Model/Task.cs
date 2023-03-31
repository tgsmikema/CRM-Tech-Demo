using System.ComponentModel.DataAnnotations;

namespace CustomerRelationManager.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TaskSummary { get; set; }
        public string TaskDescription { get; set; }
        [Required]
        public DateTime CreatedDateAndTime { get; set; }
        [Required]
        public DateTime DueDateAndTime { get; set; }
        [Required]
        public bool IsTaskDone { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }
        [Required]
        public int AssignedToUserId { get; set; }
        public int? AssignedToCustomerId { get; set; }


    }
}
