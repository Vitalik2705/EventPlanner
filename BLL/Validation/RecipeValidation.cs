using DAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class RecipeValidation : AbstractValidator<Recipe>
    {
        public RecipeValidation()
        {
            this.RuleFor(u => u.Name).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Calories).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.CookingTime).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.IngredientsUnits).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
