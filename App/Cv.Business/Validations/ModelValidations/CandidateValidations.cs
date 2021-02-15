using Cv.Models;
using System;
using System.Linq;

namespace Cv.Business.Validations
{
    public static class CandidateValidate
    {
        public static bool IsOk(CandidateModel candidate) =>
            ValidateModel<CandidateModel>.IsOk(candidate, Predicates);
        

        private static readonly Predicate<CandidateModel>[] Predicates =
        {
            (c) => !string.IsNullOrWhiteSpace(c.PersonalData.Nacionality) && c.PersonalData.Nacionality.Count() == 2
        };
    }
}
