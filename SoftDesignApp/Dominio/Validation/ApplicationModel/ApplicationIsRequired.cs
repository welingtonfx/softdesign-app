using Dominio.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
