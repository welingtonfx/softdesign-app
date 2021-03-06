﻿using Dominio.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validation.ApplicationModel
{
    public class UrlIsRequired
    {
        public IValidator<ApplicationViewModel> GetRules()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.RuleFor(p => p.Url)
                .NotEmpty()
                .WithMessage("[Url] is required");

            return validator;
        }
    }
}
