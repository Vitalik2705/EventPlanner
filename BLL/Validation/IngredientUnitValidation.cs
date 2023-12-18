using DAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class IngredientUnitValidation : AbstractValidator<IngredientUnit>
    {
        public IngredientUnitValidation()
        {
            this.RuleFor(u => u.Ingredient).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Unit).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Amount).NotNull().WithMessage("{PropertyName} mustn't be null");
            //this.RuleFor(u => u.Recipes).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
