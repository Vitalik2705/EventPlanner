using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Annotation
{
    internal class EventRecipeAnnotaion : BaseEntityAnnotation<EventRecipe>
    {
        internal EventRecipeAnnotaion(ModelBuilder builder)
            :base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.EventRecipeId);
            this.ModelBuilder.Property(u => u.EventRecipeId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("event_recipe_id");
            this.ModelBuilder.HasOne(u => u.Event).WithMany(u => u.EventRecipes).HasForeignKey(u => u.EventId);
            this.ModelBuilder.HasOne(u => u.Recipe).WithMany(u => u.RecipeEvents).HasForeignKey(u => u.RecipeId);
        }
    }
}
