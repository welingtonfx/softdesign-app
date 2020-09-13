using Dominio.ViewModel;
using FluentValidation;

namespace Dominio.Validation.ApplicationModel
{
    public class IdIsRequired
    {
        public IValidator<ApplicationViewModel> Validate()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("[Id] is required");

            validator.RuleFor(p => p.Id)
                .Length(24)
                .WithMessage("[Id] required length: 24");

            return validator;
        }
    }
}
