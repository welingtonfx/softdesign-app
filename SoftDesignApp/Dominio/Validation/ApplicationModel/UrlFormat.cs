using Dominio.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validation.ApplicationModel
{
    public class UrlFormat
    {
        public IValidator<ApplicationViewModel> Validate()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.Url)
                .Must((entity, property) => Uri.IsWellFormedUriString(property, UriKind.RelativeOrAbsolute))
                .WithMessage("[Url] format is invalid");

            return validator;
        }
    }
}
