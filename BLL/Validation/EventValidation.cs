using DAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class EventValidation : AbstractValidator<Event>
    {
        public EventValidation()
        {
            this.RuleFor(u => u.Name).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.User).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Guests).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Recipes).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
