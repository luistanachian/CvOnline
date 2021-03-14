using Cv.Models;
using Cv.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cv.Test.MockModel
{
    public static class CandidateMockModel
    {
        public static CandidateModel CandidateOk()
        {
            return new CandidateModel
            {
                CandidateId = Guid.NewGuid().ToString(),
                CompanyId = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                StarDate = DateTime.Now.AddDays(-5),
                Status = StatusCandiateEnum.ContractedOnClient,
                ClientOrSearchId = Guid.NewGuid().ToString(),
                TemporaryUser = new TemporaryUserItem
                {
                    User = "ltanachian",
                    Passeord = "12345678",
                    EndDate = DateTime.Now.AddDays(3),
                    EditPortfolios = true,
                    EditPhoto = true
                },
                Photo = "C://photo.jpg",
                Name = "Luis",
                LastName = "Tanachian",
                BirthDay = "1990-01-05",
                Sex = "M",
                Dni = "95900127",
                Nacionality = "VE",
                Occupation = "Tecnico en informatica",
                Role = "Dev .net",
                CountryId = 78,
                StateId = 689,
                AdressOne = "Bahia Blanca 317",
                AdressTwo = "Piso 2, depto F",
                PostalCode = "5000",
                Seniority = SeniorityEnum.Senior,
                Emails = new List<string> { "tanachian501@gmail.com" },
                Phones = new List<string> { "+5493517730268" },
                ListSocialNetworks = new List<string> { "https://www.facebook.com/artutanach/", "https://www.instagram.com/tanach5/" },
                ListLanguages = new List<LanguageItem>
                {
                    new LanguageItem { CodeLanguage = "ES", Level = LevelLanguageEnum.Native },
                    new LanguageItem { CodeLanguage = "EN", Level = LevelLanguageEnum.Basic }
                },
                ListPortfolios = new List<string> { "https://github.com/luistanachian" },
                WorkMode = WorkModeEnum.Any,
                Relocate = true,
                DependentsOrPets = "Esposa e hijo",
                ListEducations = new List<EducationItem>
                {
                    new EducationItem
                    {
                        CountryId = 123,
                        EdutationType = EducationTypeEnum.Technician,
                        Institute = "Upta Federico Brito Figueroa",
                        YearEnd = "2011",
                        Current = false,
                        Title = "TSU en Informatica"
                    },
                    new EducationItem
                    {
                        CountryId = 345,
                        EdutationType = EducationTypeEnum.Course,
                        Institute = "Kinetic corp",
                        YearEnd = "2020",
                        Current = false,
                        Title = ".Net Core"
                    }
                },
                ListWorkExperiences = new List<WorkExperienceItem>
                {
                    new WorkExperienceItem
                    {
                        Role = "Developer .net",
                        Company = "Bancor",
                        Current = true,
                        StartDate = "2018-05-28",
                        EndDate = null,
                        ListReferences = new List<ReferenceItem>
                        {
                            new ReferenceItem
                            {
                                Name = "Fulanito",
                                LastName = "De Tal",
                                Email = "fulanito@gmail.com",
                                Phone = "+543511234567",
                                Role = "PM",
                                WorkRelationship = WorkRelationshipEnum.Supervisor,
                                ReferenceAnswer = "Se dormia en el laburo"
                            }
                        },
                        Comment = "Trabajó para una consultora que le presta servicios a bancor"

                    }
                },
                ListSkills = new List<SkillItem>
                {
                    new SkillItem
                    {
                        Skill = "C#",
                        FrequencyUsed = FrequencyUsedEnum.EveryEay,
                        LastUsed = null,
                        Score = 9,
                        Months = 11,
                        Years = 9
                    },
                    new SkillItem
                    {
                        Skill = "SQL",
                        FrequencyUsed = FrequencyUsedEnum.EveryEay,
                        LastUsed = "2021-02-08",
                        Score = 10,
                        Months = 0,
                        Years = 9
                    }
                },
                Comments = new List<CommentItem>
                {
                    new CommentItem
                    {
                        Date = DateTime.Now,
                        User = "ltanachian",
                        Comment = "Lo llame y no contesto"
                    }
                }
            };
        }
    }
}
