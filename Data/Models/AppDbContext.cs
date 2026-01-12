using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebsiteFirstDraft.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ExerciseType> exercise_types => Set<ExerciseType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<FoodType> Food_items => Set<FoodType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ExerciseType configuration
            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.ToTable("exercise_types");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("exercise_id");
                entity.Property(e => e.ExerciseNames).HasColumnName("exercise_name");
                entity.Property(e => e.ExerciseTypes).HasColumnName("exercise_type");
                entity.Property(e => e.CaloriesBurnedPerMinute).HasColumnName("calories_burnt_per_minute");
                entity.Property(e => e.IntensityLevel).HasColumnName("intensity");
            });

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(u => u.User_id);
            });

            // FoodType configuration
            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("food_items");
                entity.HasKey(f => f.Food_Id);
            });
        }
    }
}
