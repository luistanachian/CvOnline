using Cv.Models;
using Cv.Models.Enums;
using System;
using System.Linq;

namespace Cv.Business.Validations
{
    public static class CandidateValidate
    {
        public static readonly Vali<CandidateModel>[] Predicates =
        {
            new Vali<CandidateModel>{ Validate = (c) => ((c.Status == StatusCandiateEnum.ContractedOnClient || c.Status == StatusCandiateEnum.Taken) && Validator.Guid(c.ClientOrSearchId) ||
                   (c.Status != StatusCandiateEnum.ContractedOnClient && c.Status != StatusCandiateEnum.Taken && c.ClientOrSearchId == null)), Error = "ClientOrSearchId" },
            
            new Vali<CandidateModel>{ Validate = (c) => c.TemporaryUser == null || (
                Validator.Object(c.TemporaryUser) &&
                Validator.Text(c.TemporaryUser.User, 8, 16) &&
                Validator.Text(c.TemporaryUser.Passeord, 8, 16) &&
                c.TemporaryUser.EndDate <= DateTime.Today.AddDays(7)), Error = "TemporaryUser" },

            new Vali<CandidateModel>{ Validate = (c) => c.ListSocialNetworks == null || (c.ListSocialNetworks.Count > 0 && !c.ListSocialNetworks.Any(u => !Validator.Url(u))), Error = "ListSocialNetworks" },
            new Vali<CandidateModel>{ Validate = (c) => c.ListLanguages == null || (c.ListLanguages.Count > 0 && !c.ListLanguages.Any(l => !Validator.Text(l.CodeLanguage, 2, 2))), Error = "ListLanguages" },
            new Vali<CandidateModel>{ Validate = (c) => c.ListPortfolios == null || (c.ListPortfolios.Count > 0 && !c.ListPortfolios.Any(p => !Validator.Url(p))), Error = "ListPortfolios" },
            new Vali<CandidateModel>{ Validate = (c) => c.Relocate && Validator.Text(c.DependentsOrPets, 1, 50, true), Error = "DependentsOrPets" },
            
            new Vali<CandidateModel>{ Validate = (c) => c.ListEducations == null ||
                    (c.ListEducations.Count > 0 &&
                    !c.ListEducations.Any(e =>
                        !Validator.Text(e.Institute, 1, 100) ||
                        !(Validator.Text(e.YearEnd, 4, 4) && Validator.Number(e.YearEnd)) ||
                        !Validator.Text(e.Title, 1, 100)
                    )), Error = "ListEducations" },
            
            new Vali<CandidateModel>{ Validate = (c) => c.ListWorkExperiences == null ||
                    (c.ListWorkExperiences.Count > 0 &&
                        !c.ListWorkExperiences.Any(w =>
                            !Validator.Text(w.Role, 1, 50) ||
                            !Validator.Text(w.Company, 1, 50) ||
                            !Validator.Date_YYYYMMDD(w.StartDate) ||
                            !((w.Current && w.EndDate == null) || (!w.Current && Validator.Date_YYYYMMDD(w.EndDate))) ||
                            !Validator.Text(w.Comment, 1, 200, true)
                        ) &&
                        (c.ListWorkExperiences.Any(w => w.ListReferences == null) ||
                            (c.ListWorkExperiences.Any(w => w.ListReferences.Count() > 0) &&
                            !c.ListWorkExperiences.Any(w => w.ListReferences.Any(r =>
                                !Validator.Text(r.Name, 2, 50) ||
                                !Validator.Text(r.LastName, 2, 50)||
                                !Validator.Email(r.Email) ||
                                !Validator.Phone(r.Phone) ||
                                !Validator.Text(r.Role, 1, 50, true) ||
                                !Validator.Text(r.ReferenceAnswer, 1, 200, true)
                        ))))), Error = "ListWorkExperiences" },
            
            new Vali<CandidateModel>{ Validate = (c) => c.ListSkills == null ||
                    (c.ListSkills.Count > 0 &&
                    !c.ListSkills.Any(e =>
                        !Validator.Text(e.Skill, 1, 50) ||
                        !(e.LastUsed == null || Validator.Date_YYYYMMDD(e.LastUsed)) ||
                        !(e.Score >= 1 && e.Score <= 10) ||
                        !(e.Months >= 0 && e.Score <= 11) ||
                        !(e.Years >= 0 && e.Score <= 50)
                    )), Error = "ListSkills" },
            
            new Vali<CandidateModel>{ Validate = (c) => c.Comments == null ||
                    (c.Comments.Count > 0 &&
                    !c.Comments.Any(c=>
                        !Validator.Text(c.User, 4, 16) ||
                        !Validator.Text(c.Comment, 1, 200)
                    )), Error = "Comments" }
        };
    }
}