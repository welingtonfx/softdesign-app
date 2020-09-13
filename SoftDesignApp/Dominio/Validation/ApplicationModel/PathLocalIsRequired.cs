using Dominio.ViewModel;
using FluentValidation;

namespace Dominio.Validation.ApplicationModel
{
    public class PathLocalIsRequired
    {
        public IValidator<ApplicationViewModel> GetRules()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.PathLocal)
                .NotEmpty()
                .WithMessage("[Path Local] is required");

            return validator;
        }
    }
}
