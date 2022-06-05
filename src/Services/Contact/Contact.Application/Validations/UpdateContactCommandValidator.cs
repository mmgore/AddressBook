using Contact.Application.Commands.UpdateContact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Validations
{
    internal class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(r => r.LastName).NotEmpty();

            RuleFor(r => r.Firm).NotEmpty();
        }
    }
}
