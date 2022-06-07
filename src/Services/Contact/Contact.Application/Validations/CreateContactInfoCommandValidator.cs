using Contact.Application.Commands.CreateContactInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Validations
{
    public class CreateContactInfoCommandValidator : AbstractValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoCommandValidator()
        {
            RuleFor(r => r.PhoneNumber).NotEmpty()
                .WithMessage("Phone Number is required");

            RuleFor(r => r.EmailAddress).NotEmpty()
                .WithMessage("Email Address is required");

            RuleFor(r => r.Location).NotEmpty()
                .WithMessage("Location is required");

            RuleFor(r => r.Content).NotEmpty()
                .WithMessage("Content is required");
        }
    }
}
