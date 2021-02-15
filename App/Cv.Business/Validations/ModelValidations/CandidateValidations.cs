using Cv.Models;
using Cv.Models.Enums;
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
            (c) => ((c.Status == StatusCandiateEnum.ContractedOnClient || c.Status == StatusCandiateEnum.Taken) && Validator.Guid(c.ClientOrSearchId) ||
                   (c.Status != StatusCandiateEnum.ContractedOnClient && c.Status != StatusCandiateEnum.Taken && c.ClientOrSearchId == null)),
            (c) => Validator.Text(c.Nacionality, 2)
        };
    }
}
