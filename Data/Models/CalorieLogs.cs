using System.ComponentModel.DataAnnotations;
using WebsiteFirstDraft.Components.Pages.Diet_Food;

namespace WebsiteFirstDraft.Data.Models
{
    // Represents a log entry for calorie tracking. New table on SQL Server. Required for graphs to work
    public class CalorieLogs
    {
        // Primary key for the CalorieLogs table
        [Key]
        public int CalorieLog_Id { get; set; }

        // Foreign key referencing the user
        [Required]
        public int User_id { get; set; } 

        [Required]
        public DateTime Log_Date { get; set; }

        // Nullable integer for calories consumed
        public int? Calories_Consumed { get; set; }

        
        public int? Calories_Burned { get; set; }

        [Required]
        public int Net_Calories { get; set; }
    }
}
