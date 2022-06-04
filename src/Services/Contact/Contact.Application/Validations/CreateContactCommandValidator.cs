using Contact.Application.Commands.CreateContact;
using FluentValidation;

namespace Contact.Application.Validations
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(r => r.LastName).NotEmpty();

            RuleFor(r => r.Firm).NotEmpty();

            RuleFor(r => r.PhoneNumber).NotEmpty();

            RuleFor(r => r.EmailAddress).NotEmpty();
            
            RuleFor(r => r.Location).NotEmpty();
            
            RuleFor(r => r.Content).NotEmpty();
        }
    }
}
