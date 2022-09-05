using System;
using System.Collections.Generic;
using Meal_Planner_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Meal_Planner_API.Data
{
    public partial class MealPlannerContext : DbContext
    {
        IConfiguration _config;
        public MealPlannerContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        public MealPlannerContext(IConfiguration configuration, DbContextOptions<MealPlannerContext> options)
            : base(options)
        {
            _config = configuration;
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; } = null!;
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public virtual DbSet<RecipeTag> RecipeTags { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(_config.GetConnectionString("MealPlanner"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.IngredientCategory)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IngredientCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingredien__Ingre__145C0A3F");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeIng__Ingre__1A14E395");

                entity.HasOne(d => d.MeasureUnit)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.MeasureUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeIng__Measu__1B0907CE");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeIng__Recip__1920BF5C");
            });

            modelBuilder.Entity<RecipeTag>(entity =>
            {
                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeTags)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeTag__Recip__1FCDBCEB");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.RecipeTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeTag__TagId__20C1E124");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Value).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
