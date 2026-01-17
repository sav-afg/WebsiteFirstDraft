using System.ComponentModel.DataAnnotations;

namespace WebsiteFirstDraft.Data.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = "";

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = "";
        public string Phone_Number { get; set; } = "";
        public string Role { get; set; } = "User";
        public int Login_Streak { get; set; }
        public int Daily_Calories { get; set; }
        public int Daily_Carbs { get; set; }
        public int Daily_Protein { get; set; }
        public int Daily_Fat { get; set; }
        public int Weekly_Calories { get; set; }
        public int Weekly_Carbs { get; set; }
        public int Weekly_Protein { get; set; }
        public int Weekly_Fat { get; set; }
        public int Total_Calories { get; set; }
        public bool High_Contrast_Mode { get; set; } = false;
        public bool Dyslexia_Friendly_Font { get; set; } = false;
        public bool Reduced_Animations { get; set; } = false;
        public bool Larger_Font_Size { get; set; } = false;
        public string Tracking_Preferences { get; set; } = "";
        public bool Visual_Rewards { get; set; } = true;
        public bool Progress_Data { get; set; } = true;
        public bool Minimal_Interface { get; set; } = false;

        // New fields 

        public int Body_Weight { get; set; }
        public int Maintenance_Calories { get; set; }

        public double Daily_Weight_Change { get; set; }

        public double Weekly_Weight_Change { get; set; }

        public int Daily_Calories_Burnt_Through_Exercise { get; set; }

        public int Weekly_Calories_Burnt_Through_Exercise { get; set; }

        public int Daily_Cardio { get; set; }
        public int Daily_Strength { get; set; }
        public int Daily_Flexibility { get; set; }

        public DateTime Created_At { get; set; } = DateTime.UtcNow;
    }

}
