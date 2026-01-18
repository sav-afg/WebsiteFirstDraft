using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteFirstDraft.Data.Models
{
    // Table to link users with their food items
    public class UserFoodItems
    {
        [Key]
        [Column("users_food_item_id")]
        public int UsersFoodItemId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Required]
        [Column("food_id")]
        public int FoodId { get; set; }

        [Required]
        [Column("date_added")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; } = null!;
        public FoodType FoodType { get; set; } = null!;
    }
}
