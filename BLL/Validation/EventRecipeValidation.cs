using DAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class EventRecipeValidation : AbstractValidator<EventRecipe>
    {
        public EventRecipeValidation()
        {
            this.RuleFor(u => u.EventId).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.RecipeId).NotNull().WithMessage("{PropertyName} mustn't be null");
            //this.RuleFor(u => u.Event).NotNull().WithMessage("{PropertyName} mustn't be null");
            //this.RuleFor(u => u.Recipe).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
