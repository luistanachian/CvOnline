using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv.Models
{
    public class CandidateValidations : AbstractValidator<CandidateModel>
    {
        public CandidateValidations()
        {
            RuleFor(x => x.PersonalData).NotNull();
            RuleFor(x => x.PersonalData.FullName).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
        }

        //public Dictionary<string, string> ValidateRules(CandidateModel entity)
        //{
        //    Dictionary<string, string> result = new();
        //    ValidationResult validationResult = this.Validate(entity);
        //    if(!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //            result.Add(error.PropertyName, error.ErrorMessage);
        //    }
        //    return result;
        //}
    }
}
