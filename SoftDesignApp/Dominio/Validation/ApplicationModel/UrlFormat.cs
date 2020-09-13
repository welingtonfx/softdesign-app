using Dominio.ViewModel;
using FluentValidation;
using System;

namespace Dominio.Validation.ApplicationModel
{
    public class UrlFormat
    {
        public IValidator<ApplicationViewModel> GetRules()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.Url)
                .Must((entity, property) => Uri.IsWellFormedUriString(property, UriKind.RelativeOrAbsolute))
                .WithMessage("[Url] format is invalid");

            return validator;
        }
    }
}
