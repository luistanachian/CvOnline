using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Cv.Models
{
    public class BaseValidateFluent<T> : AbstractValidator<T>
    {
        public static (bool Valido, Dictionary<string, string> Errores) ValidateRules(AbstractValidator<T> validator, T entity)
        {
            bool valido = true;
            Dictionary<string, string> listErrors = new();
            ValidationResult validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                valido = false;
                foreach (var error in validationResult.Errors)
                    listErrors.Add(error.PropertyName, error.ErrorMessage);
            }
            return (valido, listErrors);
        }
    }
}