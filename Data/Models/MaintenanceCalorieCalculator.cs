namespace WebsiteFirstDraft.Data.Models
{
    
    // Service class for calculating daily maintenance calories based on user inputs
    // Uses the Mifflin-St Jeor Equation for BMR calculation  
    public class MaintenanceCalorieCalculator
    {
        // Basic user information
        public string Sex { get; set; } = string.Empty;
        public double HeightCm { get; set; }
        public double WeightKg { get; set; }
        public int Age { get; set; }

        // Activity and exercise information
        public PhysicalActivityLevel ActivityLevel { get; set; }
        public ExerciseFrequency ExerciseFrequency { get; set; }

        
        // Calculates Basal Metabolic Rate (BMR) using Mifflin-St Jeor Equation
        // Men: BMR = 10 × weight(kg) + 6.25 × height(cm) - 5 × age(y) + 5
        // Women: BMR = 10 × weight(kg) + 6.25 × height(cm) - 5 × age(y) - 161     
        public double CalculateBMR()
        {
            double bmr = (10 * WeightKg) + (6.25 * HeightCm) - (5 * Age);

            // Case insensitive string comparison
            if (Sex.Equals("Male", StringComparison.OrdinalIgnoreCase))
            {
                bmr += 5;
            }
            else if (Sex.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                bmr -= 161;
            }

            return bmr;
        }

        
        // Calculates Total Daily Energy Expenditure by applying activity multiplier to BMR
        
        public double CalculateTDEE()
        {
            double bmr = CalculateBMR();
            double activityMultiplier = GetActivityMultiplier();
            return bmr * activityMultiplier;
        }

        
        // Returns the activity multiplier based on physical activity level and exercise frequency

        
        private double GetActivityMultiplier()
        {
            // Base multiplier from physical activity level
            double baseMultiplier = ActivityLevel switch
            {
                PhysicalActivityLevel.NoExercise => 1.2,
                PhysicalActivityLevel.RegularExercise => 1.375,
                PhysicalActivityLevel.PhysicalJob => 1.55,
                PhysicalActivityLevel.Athlete => 1.725,
                _ => 1.2
            };

            // Additional multiplier from exercise frequency
            double exerciseBonus = ExerciseFrequency switch
            {
                ExerciseFrequency.LessThanOnce => 0.0,
                ExerciseFrequency.OnceToTwice => 0.05,
                ExerciseFrequency.TwoToThree => 0.1,
                ExerciseFrequency.ThreeToFive => 0.15,
                ExerciseFrequency.SixToSeven => 0.2,
                _ => 0.0
            };

            return baseMultiplier + exerciseBonus;
        }

        
        // Resets all properties to default values
        public void Reset()
        {
            Sex = String.Empty;
            HeightCm = 0;
            WeightKg = 0;
            Age = 0;
            ActivityLevel = PhysicalActivityLevel.NoExercise;
            ExerciseFrequency = ExerciseFrequency.LessThanOnce;
        }
    }


    // Represents the user's general physical activity level
    public enum PhysicalActivityLevel
    {
        NoExercise,
        RegularExercise,
        PhysicalJob,
        Athlete
    }


    // Represents how often the user exercises per week
    public enum ExerciseFrequency
    {
        LessThanOnce,
        OnceToTwice,
        TwoToThree,
        ThreeToFive,
        SixToSeven
    }
}
