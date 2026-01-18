using System.ComponentModel.DataAnnotations;

namespace WebsiteFirstDraft.Data.DatabaseTableModels
{
    public class FoodType
    {
        [Key]
        public int Food_Id { get; set; }
        public string Food_Name { get; set; } = string.Empty;
        public string Food_Type { get; set; } = string.Empty;
        public double Calories_Per_Gram { get; set; }
        public double Carbs_Per_Gram { get; set; }
        public double Protein_Per_Gram { get; set; }
        public double Fat_Per_Gram { get; set; }

    }
}
