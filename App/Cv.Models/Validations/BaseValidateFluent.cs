using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Models
{
    public class BaseValidateFluent<T> : AbstractValidator<T>
    {
        public static (bool Valido, Dictionary<string, List<string>> Errores) ValidateRules(AbstractValidator<T> validator, T entity)
        {
            bool valido = true;
            Dictionary<string, List<string>> listErrors = new();
            ValidationResult validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                valido = false;
                foreach (var error in validationResult.Errors)
                {
                    if(listErrors.Any(x => x.Key == error.PropertyName))
                    {
                        listErrors.FirstOrDefault(x => x.Key == error.PropertyName).Value.Add(error.ErrorMessage);
                        continue;
                    }
                    listErrors.Add(error.PropertyName, new List<string> { error.ErrorMessage });
                }
            }
            return (valido, listErrors);
        }
    }
}