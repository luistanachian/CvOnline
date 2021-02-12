using Cv.Business.Interface;
using Cv.Ioc;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Cv.Models;
using System.Collections.Generic;
using Cv.Models.Enums;

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
            TestCandidates();
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


        public void TestCandidates()
        {
            Console.WriteLine("TestCandidates");

            Console.WriteLine();
            Console.WriteLine("TestCandidates - Insert Start");


            var candidate = new CandidateModel
            {
                CompanyId = "holaCompany",
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
                Education = EducationTypeEnum.Technician,
                ListLanguages = new List<LanguageModel>
                {
                    new LanguageModel{ CodeLanguage = "ES", Level = LevelLanguageEnum.Native },
                    new LanguageModel{ CodeLanguage = "EN", Level = LevelLanguageEnum.Basic }
                },
                Relocate = new RelocateModel
                {
                    Children = 1,
                    Married = true,
                    Pet = false,
                    EstimateDate = DateTime.Today,
                    Comments = "Me faltan algunos documentos de Venezuela"
                },
                EMails = new List<string> { "tanachian501@gmail.com" },
                Phones = new List<string> { "+5493517730268" },
                ListSocialNetworks = new List<string> { "Facebook", "Instagram" },
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
                ListSkills = null, //TODO terminar de probar
                ListWorkExperiences = null//TODO terminar de probar
            };
            candidatesBusiness.Insert(candidate);
            Console.WriteLine("TestCandidates - Insert End");
        }

    }
}