using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteFirstDraft.Data.DatabaseTableModels
{
    // The UserExercises class represents the relationship between users and exercises in the database.
    public class UserExercises
    {
        [Key]
        [Column("users_exercise_id")]
        public int UserExerciseId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("exercise_id")]
        public int ExerciseId { get; set; }

        [Required]
        [Column("date_added")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public required User User { get; set; } 
        public required ExerciseType Exercise { get; set; }
    }
}
