// <copyright file="UserValidation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Validation
{
    using DAL.Models;
    using FluentValidation;
    using System.Text.RegularExpressions;

    public class RegisterValidation : AbstractValidator<User>
    {
        public RegisterValidation()
        {
            this.RuleFor(u => u.Surname).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.Name).NotNull().WithMessage("{PropertyName} mustn't be null");
            this.RuleFor(u => u.PhoneNumber).NotNull().Custom((number, context) =>
            {
                if (number.Length != 10)
                {
                    context.AddFailure("The phone number must have 10 digits");
                }

                if (!number.StartsWith("0"))
                {
                    context.AddFailure("Invalid phone number. It must start with 0");
                }
            });
            this.RuleFor(u => u.Email).NotNull().Custom((email, context) =>
            {
                if (!email.Contains("@"))
                {
                    context.AddFailure("Email must contain @");
                }

                if (!email.Contains("."))
                {
                    context.AddFailure("Email must contain .");
                }
            });
            this.RuleFor(u => u.Password).NotNull().Custom((password, context) =>
            {
                //string patternNumbers = "^[0-9]+$";
                //string patternUpperLetters = "^[A-Z]+$";
                //string patternLowerLetters = "^[a-z]+$";
                //if (password.Length < 8)
                //{
                //    context.AddFailure("Password must have at least 8 values");
                //}

                //if (!Regex.Match(password, patternNumbers).Success)
                //{
                //    context.AddFailure("Password must contain at least one digit");
                //}

                //if (!Regex.Match(password, patternUpperLetters).Success)
                //{
                //    context.AddFailure("Password must contain at least one upper letter");
                //}

                //if (!Regex.Match(password, patternLowerLetters).Success)
                //{
                //    context.AddFailure("Password must contain at least one lower letter");
                //}
            });
            this.RuleFor(u => u.Gender).NotNull().WithMessage("{PropertyName} mustn't be null");
        }
    }
}
