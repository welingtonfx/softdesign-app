using Dominio.ViewModel;
using FluentValidation;

namespace Dominio.Validation.ApplicationModel
{
    public class ApplicationIsRequired
    {
        public IValidator<ApplicationViewModel> GetRules()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.Application)
                .NotEmpty()
                .WithMessage("[Application] is required");

            return validator;
        }
    }
}
