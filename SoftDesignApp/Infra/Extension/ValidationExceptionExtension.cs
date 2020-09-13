using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Extension
{
    public static class ValidationExceptionExtension
    {
        public static IEnumerable<string> GetErrorMessages(this ValidationException exception)
        {
            if (exception.Errors.NotNullAndAny())
                return exception.Errors.Select(p => p.ErrorMessage);

            return Enumerable.Empty<string>();
        }
    }
}
