using Cv.Business.Interface;
using Cv.Ioc;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Cv.Models;
using System.Collections.Generic;
using Cv.Models.Enums;
using System.Linq;

namespace Cv.AppConsole
{
    public class Program
    {
        private readonly ICountriesBusiness countriesBusiness;
        private readonly IStatesBusiness statesBusiness;
        private readonly ICandidatesBusiness candidatesBusiness;
        public Program(
            ICountriesBusiness countriesBusiness,
            IStatesBusiness statesBusiness,
            ICandidatesBusiness candidatesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
            this.statesBusiness = statesBusiness;
            this.candidatesBusiness = candidatesBusiness;
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public void Run()
        {
            //TestCountries();
            TestCandidatesDelete();
            TestCandidatesInsert();
            Console.ReadKey();
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddTransient<Program>();
                services.ConfigureIOC();
            });
        }


        public void TestCountries()
        {
            Console.WriteLine("TestCountries");

            Console.WriteLine();
            Console.WriteLine("TestCountries - GetAll");
            var list = countriesBusiness.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.CodeCountry} - {item.Country}");
            }

            Console.WriteLine();
            var country = countriesBusiness.GetById("VE");
            Console.WriteLine($"TestCountries - GetById('{country.CodeCountry}')");
            Console.WriteLine($"{country.CodeCountry} - {country.Country}");
        }


        public void TestCandidatesDelete()
        {
            candidatesBusiness.Replace(new CandidateModel());
            string company = "holaCompany";
            var list = new List<CandidateModel>();

            Console.WriteLine("TestCandidates - Get Start");
            list = candidatesBusiness.GetAllByCompanyId(company).ToList();
            Console.WriteLine("TestCandidates - Get End");

            Console.WriteLine("TestCandidates - Delete Start");

            foreach (var item in list)
                candidatesBusiness.Delete(item.CandidateId);

            Console.WriteLine("TestCandidates - Delete End");
        }
        public void TestCandidatesInsert()
        {
            string company = "holaCompany";
            Console.WriteLine("TestCandidates - Insert Start");

            var candidate = new CandidateModel
            {
                CompanyId = company,
                Status = StatusCandiateEnum.ContractedOnClient,
                ClientOrSearchId = Guid.NewGuid().ToString(),
                StarDate = DateTime.Now.AddDays(-5),
                LastUpdate = DateTime.Now,
                TemporaryUser = new TemporaryUserModel
                {
                    User = "ltanachian",
                    Passeord = "1234",
                    EndDate = DateTime.Now.AddDays(3),
                    EditPortfolios = true,
                    EditPhoto = true
                },
                Photo = "C://photo.jpg",
                PersonalData = new PersonalDataModel
                {
                    Name = "Luis",
                    LastName = "Tanachian",
                    BirthDay = "1990-01-05",
                    Sex = "M",
                    Dni = "95900127",
                    Nacionality = "VE",
                    Occupation = "Tecnico en informatica",
                    Role = "Dev .net",
                    Adress = new AdressModel
                    {
                        Country = "AR",
                        State = "Cordoba",
                        Location = "Cordoba Capital",
                        Street = "Bahia Blanca",
                        Number = "317",
                        Floor = "2",
                        Department = "F",
                        PostalCode = "5000"

                    },
                    Seniority = SeniorityEnum.Senior,
                    EMails = new List<string> { "tanachian501@gmail.com" },
                    Phones = new List<string> { "+5493517730268" },
                    ListSocialNetworks = new List<string> { "Facebook", "Instagram" },
                },
                ListLanguages = new List<LanguageModel>
                {
                    new LanguageModel { CodeLanguage = "ES", Level = LevelLanguageEnum.Native },
                    new LanguageModel { CodeLanguage = "EN", Level = LevelLanguageEnum.Basic }
                },
                Relocate = new RelocateModel
                {
                    Children = 1,
                    Married = true,
                    Pet = false,
                    EstimateDate = DateTime.Today,
                    Comments = "Me faltan algunos documentos de Venezuela" //TODO lista de commentModel
                },
                ListPortfolios = new List<string> { "GitHub", "GitLab" },
                ListEducations = new List<EducationModel>
                {
                    new EducationModel
                    {
                        CodeCountry = "VE",
                        EdutationType = EducationTypeEnum.Technician,
                        Institute = "Upta Federico Brito Figueroa",
                        StartDate = "2007",
                        EndDate = "2011",
                        Current = false,
                        Title = "TSU en Informatica"
                    },
                    new EducationModel
                    {
                        CodeCountry = "AR",
                        EdutationType = EducationTypeEnum.Course,
                        Institute = "Kinetic corp",
                        StartDate = "2020-06",
                        EndDate = "2020-06",
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
                        StartDate = DateTime.Parse("2018-05-28"),
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
                        Comments = new List<CommentModel>
                        {
                            new CommentModel
                            {
                                Date = DateTime.Now,
                                User = "ltanachian",
                                Comment = "Trabajó para una consultora que le presta servicios a bancor"
                            }
                        }

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
            var insertado = candidatesBusiness.Insert(candidate);
            Console.WriteLine();
            Console.WriteLine($"TestCandidates - Insert Result {insertado}");
            Console.WriteLine();
            Console.WriteLine("TestCandidates - Insert End");
        }

    }
}