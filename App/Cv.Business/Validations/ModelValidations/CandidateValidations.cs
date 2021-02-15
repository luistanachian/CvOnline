using Cv.Models;
using System;
using System.Linq;

namespace Cv.Business.Validations
{
    public static class CandidateValidate
    {
        public static readonly Predicate<CandidateModel>[] Predicates =
        {
            (c) => Validator.Guid(c.CandidateId),
            (c) => Validator.Guid(c.CompanyId),
            (c) => Validator.Object(c.PersonalData) && Validator.Text(c.PersonalData.Nacionality, 2)
        };
    }
}
