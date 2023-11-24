using DAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class GuestValidation : AbstractValidator<Guest>
    {
        public GuestValidation()
        {
            this.RuleFor(u => u.Surname).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Name).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Gender).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
