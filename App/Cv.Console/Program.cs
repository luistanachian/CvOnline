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
            //aca va todo lo que se necesita ejecutar
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddTransient<Program>();
                services.ConfigureIOC();
            });
        }

    }
}