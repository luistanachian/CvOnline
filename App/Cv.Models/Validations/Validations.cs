using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cv.Models
{
    public static class Validations
    {
        public static (bool valid, Dictionary<string, List<string>> errores) IsValid<Tentity, TabstractValidator>(Tentity entity)
            where Tentity : class
            where TabstractValidator : AbstractValidator<Tentity>
        {
            bool valido = true;
            Dictionary<string, List<string>> errores = new();

            var ctor = typeof(TabstractValidator).GetConstructor(Type.EmptyTypes);
            var validator = (AbstractValidator<Tentity>)ctor.Invoke(new object[] { });
            ValidationResult validationResult = validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                valido = false;
                foreach (var error in validationResult.Errors)
                {
                    if (errores.Any(x => x.Key == error.PropertyName))
                    {
                        errores.FirstOrDefault(x => x.Key == error.PropertyName).Value.Add(error.ErrorMessage);
                        continue;
                    }
                    errores.Add(error.PropertyName, new List<string> { error.ErrorMessage });
                }
            }
            return (valido, errores);
        }
    }
}