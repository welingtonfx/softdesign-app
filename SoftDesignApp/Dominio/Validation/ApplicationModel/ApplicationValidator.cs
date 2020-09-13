using Dominio.Interface;
using Dominio.ViewModel;
using FluentValidation;

namespace Dominio.Validation.ApplicationModel
{
    public class ApplicationValidator : IApplicationValidator
    {
        private  InlineValidator<ApplicationViewModel> GetRules()
        {
            var validator = new InlineValidator<ApplicationViewModel>();

            validator.Include(new ApplicationIsRequired().GetRules());
            validator.Include(new UrlIsRequired().GetRules());
            validator.Include(new UrlFormat().GetRules());
            validator.Include(new PathLocalIsRequired().GetRules());

            return validator;
        }

        public void ValidateAndThrow(ApplicationViewModel application)
        {
            this.GetRules().ValidateAndThrow(application);
        }
    }
}
