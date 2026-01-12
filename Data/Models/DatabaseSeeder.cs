namespace WebsiteFirstDraft.Data.Models
{
    /// <summary>
    /// Seeds the in-memory database with mock data for testing
    /// </summary>
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(AppDbContext context)
        {
            // Check if data already exists to avoid duplicates
            if (context.Users.Any() || context.exercise_types.Any() || context.Food_items.Any())
            {
                return; // Database already seeded
            }

            SeedUsers(context);
            SeedExercises(context);
            SeedFoods(context);

            context.SaveChanges();
        }

        private static void SeedUsers(AppDbContext context)
        {
            var users = new[]
            {
                new User
                {
                    User_id = 1,
                    Username = "testuser",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                    Email = "testuser@example.com",
                    Phone_Number = "555-0001",
                    Role = "User",
                    Login_Streak = 5,
                    High_Contrast_Mode = true,
                    Dyslexia_Friendly_Font = false,
                    Larger_Font_Size = true,
                    Visual_Rewards = true,
                    Progress_Data = true,
                    Tracking_Preferences = "Calories,Macros,WeightTrends"
                },
                new User
                {
                    User_id = 2,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Email = "admin@example.com",
                    Phone_Number = "555-0002",
                    Role = "Admin",
                    Login_Streak = 10,
                    High_Contrast_Mode = false,
                    Dyslexia_Friendly_Font = true,
                    Reduced_Animations = true,
                    Minimal_Interface = true
                },
                new User
                {
                    User_id = 3,
                    Username = "johndoe",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("john123"),
                    Email = "john@example.com",
                    Phone_Number = "555-0003",
                    Role = "User",
                    Login_Streak = 3,
                    Daily_Calories = 2000,
                    Daily_Protein = 150,
                    Daily_Carbs = 200,
                    Daily_Fat = 70,
                    Tracking_Preferences = "Calories,Exercise,AdvancedMetrics"
                }
            };

            context.Users.AddRange(users);
        }

        private static void SeedExercises(AppDbContext context)
        {
            var exercises = new[]
            {
                new ExerciseType
                {
                    Id = 1,
                    ExerciseNames = "Running",
                    ExerciseTypes = "Cardio",
                    CaloriesBurnedPerMinute = 10.5,
                    IntensityLevel = "High"
                },
                new ExerciseType
                {
                    Id = 2,
                    ExerciseNames = "Walking",
                    ExerciseTypes = "Cardio",
                    CaloriesBurnedPerMinute = 4.0,
                    IntensityLevel = "Low"
                },
                new ExerciseType
                {
                    Id = 3,
                    ExerciseNames = "Cycling",
                    ExerciseTypes = "Cardio",
                    CaloriesBurnedPerMinute = 8.5,
                    IntensityLevel = "Medium"
                },
                new ExerciseType
                {
                    Id = 4,
                    ExerciseNames = "Bench Press",
                    ExerciseTypes = "Strength",
                    CaloriesBurnedPerMinute = 6.0,
                    IntensityLevel = "High"
                },
                new ExerciseType
                {
                    Id = 5,
                    ExerciseNames = "Squats",
                    ExerciseTypes = "Strength",
                    CaloriesBurnedPerMinute = 7.5,
                    IntensityLevel = "High"
                },
                new ExerciseType
                {
                    Id = 6,
                    ExerciseNames = "Yoga",
                    ExerciseTypes = "Flexibility",
                    CaloriesBurnedPerMinute = 3.0,
                    IntensityLevel = "Low"
                },
                new ExerciseType
                {
                    Id = 7,
                    ExerciseNames = "Swimming",
                    ExerciseTypes = "Cardio",
                    CaloriesBurnedPerMinute = 9.0,
                    IntensityLevel = "Medium"
                },
                new ExerciseType
                {
                    Id = 8,
                    ExerciseNames = "Deadlift",
                    ExerciseTypes = "Strength",
                    CaloriesBurnedPerMinute = 8.0,
                    IntensityLevel = "High"
                }
            };

            context.exercise_types.AddRange(exercises);
        }

        private static void SeedFoods(AppDbContext context)
        {
            var foods = new[]
            {
                new FoodType
                {
                    Food_Id = 1,
                    Food_Name = "Chicken Breast",
                    Food_Type = "Protein",
                    Calories_Per_Gram = 1.65,
                    Protein_Per_Gram = 0.31,
                    Carbs_Per_Gram = 0.0,
                    Fat_Per_Gram = 0.036
                },
                new FoodType
                {
                    Food_Id = 2,
                    Food_Name = "Brown Rice",
                    Food_Type = "Carbohydrate",
                    Calories_Per_Gram = 1.12,
                    Protein_Per_Gram = 0.026,
                    Carbs_Per_Gram = 0.23,
                    Fat_Per_Gram = 0.009
                },
                new FoodType
                {
                    Food_Id = 3,
                    Food_Name = "Broccoli",
                    Food_Type = "Vegetable",
                    Calories_Per_Gram = 0.34,
                    Protein_Per_Gram = 0.028,
                    Carbs_Per_Gram = 0.07,
                    Fat_Per_Gram = 0.004
                },
                new FoodType
                {
                    Food_Id = 4,
                    Food_Name = "Salmon",
                    Food_Type = "Protein",
                    Calories_Per_Gram = 2.08,
                    Protein_Per_Gram = 0.20,
                    Carbs_Per_Gram = 0.0,
                    Fat_Per_Gram = 0.13
                },
                new FoodType
                {
                    Food_Id = 5,
                    Food_Name = "Banana",
                    Food_Type = "Fruit",
                    Calories_Per_Gram = 0.89,
                    Protein_Per_Gram = 0.011,
                    Carbs_Per_Gram = 0.23,
                    Fat_Per_Gram = 0.003
                },
                new FoodType
                {
                    Food_Id = 6,
                    Food_Name = "Almonds",
                    Food_Type = "Fat",
                    Calories_Per_Gram = 5.79,
                    Protein_Per_Gram = 0.21,
                    Carbs_Per_Gram = 0.22,
                    Fat_Per_Gram = 0.49
                },
                new FoodType
                {
                    Food_Id = 7,
                    Food_Name = "Oatmeal",
                    Food_Type = "Carbohydrate",
                    Calories_Per_Gram = 3.89,
                    Protein_Per_Gram = 0.17,
                    Carbs_Per_Gram = 0.66,
                    Fat_Per_Gram = 0.07
                },
                new FoodType
                {
                    Food_Id = 8,
                    Food_Name = "Greek Yogurt",
                    Food_Type = "Protein",
                    Calories_Per_Gram = 0.59,
                    Protein_Per_Gram = 0.10,
                    Carbs_Per_Gram = 0.036,
                    Fat_Per_Gram = 0.004
                },
                new FoodType
                {
                    Food_Id = 9,
                    Food_Name = "Sweet Potato",
                    Food_Type = "Carbohydrate",
                    Calories_Per_Gram = 0.86,
                    Protein_Per_Gram = 0.016,
                    Carbs_Per_Gram = 0.20,
                    Fat_Per_Gram = 0.001
                },
                new FoodType
                {
                    Food_Id = 10,
                    Food_Name = "Eggs",
                    Food_Type = "Protein",
                    Calories_Per_Gram = 1.55,
                    Protein_Per_Gram = 0.13,
                    Carbs_Per_Gram = 0.011,
                    Fat_Per_Gram = 0.11
                }
            };

            context.Food_items.AddRange(foods);
        }
    }
}