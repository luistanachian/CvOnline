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
                Status = StatusCandiateEnum.ContractedOnClient,
                ClientOrSearchId = Guid.NewGuid().ToString(),
                StarDate = DateTime.Now.AddDays(-5),
                LastUpdate = DateTime.Now,
                TemporaryUser = new TemporaryUserModel
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
                Country = "AR",
                State = "Cordoba",
                Location = "Cordoba Capital",
                AdressOne = "Bahia Blanca 317",
                AdressTwo = "Piso 2, depto F",
                PostalCode = "5000",
                Seniority = SeniorityEnum.Senior,
                EMails = new List<string> { "tanachian501@gmail.com" },
                Phones = new List<string> { "+5493517730268" },
                ListSocialNetworks = new List<string> { "https://www.facebook.com/artutanach/", "https://www.instagram.com/tanach5/" },
                ListLanguages = new List<LanguageModel>
                {
                    new LanguageModel { CodeLanguage = "ES", Level = LevelLanguageEnum.Native },
                    new LanguageModel { CodeLanguage = "EN", Level = LevelLanguageEnum.Basic }
                },
                ListPortfolios = new List<string> { "https://github.com/luistanachian" },
                WorkMode = WorkModeEnum.Any,
                Relocate = new RelocateModel
                {
                    RelocateDependentsOrPets = "Esposa e hijo",
                    RelocateEstimateDate = "2021-02-20"
                },
                ListEducations = new List<EducationModel>
                {
                    new EducationModel
                    {
                        Country = "VE",
                        EdutationType = EducationTypeEnum.Technician,
                        Institute = "Upta Federico Brito Figueroa",
                        YearEnd = "2011",
                        Current = false,
                        Title = "TSU en Informatica"
                    },
                    new EducationModel
                    {
                        Country = "AR",
                        EdutationType = EducationTypeEnum.Course,
                        Institute = "Kinetic corp",
                        YearEnd = "2020",
                        Current = false,
                        Title = ".Net Core"
                    }
                },
                ListWorkExperiences = new List<WorkExperienceModel>
                {
                    new WorkExperienceModel
                    {
                        Role = "Developer .net",
                        Company = "Bancor",
                        Current = true,
                        StartDate = "2018-05-28",
                        EndDate = null,
                        ListReferences = new List<ReferenceModel>
                        {
                            new ReferenceModel
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
                ListSkills = new List<SkillModel>
                {
                    new SkillModel
                    {
                        Skill = "C#",
                        FrequencyUsed = FrequencyUsedEnum.EveryEay,
                        Current = true,
                        LastUsed = null,
                        Score = 9,
                        Years = 9
                    },
                    new SkillModel
                    {
                        Skill = "SQL",
                        FrequencyUsed = FrequencyUsedEnum.EveryEay,
                        Current = true,
                        LastUsed = null,
                        Score = 9,
                        Years = 9
                    }
                },
                Comments = new List<CommentModel>
                {
                    new CommentModel
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
