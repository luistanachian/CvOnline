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
            (c) => c.TemporaryUser == null || (
                Validator.Object(c.TemporaryUser) &&
                Validator.Text(c.TemporaryUser.User, 8, 16) &&
                Validator.Text(c.TemporaryUser.Passeord, 8, 16) &&
                c.TemporaryUser.EndDate <= DateTime.Today.AddDays(7)),
            (c) => Validator.Text(c.Photo, 1, 100, true),
            (c) => Validator.Text(c.Name, 2, 50),
            (c) => Validator.Text(c.LastName, 2, 50),
            (c) => Validator.Date_YYYYMMDD(c.BirthDay),
            (c) => Validator.Text(c.Sex, 1, 1),
            (c) => Validator.Text(c.Dni, 6, 11),
            (c) => Validator.Text(c.Nacionality, 2, 2, true),
            (c) => Validator.Text(c.Occupation, 1, 50, true),
            (c) => Validator.Text(c.Role, 1, 50, true),
            (c) => Validator.Text(c.Country, 2, 2),
            (c) => Validator.Text(c.State, 1, 50),
            (c) => Validator.Text(c.Location, 1, 50, true),
            (c) => Validator.Text(c.AdressOne, 1, 100, true),
            (c) => Validator.Text(c.AdressTwo, 1, 100, true),
            (c) => !c.EMails.Any(e => !Validator.Email(e)),
            (c) => !c.Phones.Any(p => !Validator.Phone(p)),
            (c) => c.ListSocialNetworks == null || (c.ListSocialNetworks.Count > 0 && !c.ListSocialNetworks.Any(u => !Validator.Url(u))),
            (c) => c.ListLanguages == null || (c.ListLanguages.Count > 0 && !c.ListLanguages.Any(l => !Validator.Text(l.CodeLanguage, 2, 2))),
            //(c) => c.ListPortfolios == null || (c.ListPortfolios.Count > 0 && !c.ListPortfolios.Any(p => !Validator.Url(p))),
        };
    }
}
