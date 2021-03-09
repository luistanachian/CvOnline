using Cv.Business.Interface;
using Cv.Ioc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Cv.Models.Enums;
using Cv.Models;
using System;
using System.Collections.Generic;
using Cv.Dao.Configurations;
using MongoDB.Driver;
using System.Threading.Tasks;
using Cv.Models.Mock;

namespace Cv.AppConsole
{
    public class Program
    {
        private readonly ICountriesBusiness countriesBusiness;
        private readonly ICandidatesBusiness candidatesBusiness;
        private readonly IStatesBusiness statesBusiness;
        public Program(
            ICountriesBusiness countriesBusiness,
            ICandidatesBusiness candidatesBusiness,
            IStatesBusiness statesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
            this.candidatesBusiness = candidatesBusiness;
            this.statesBusiness = statesBusiness;
        }

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.Services.GetRequiredService<Program>().Run();
        }

        public async Task Run()
        {
            //var can = CandidateMock.CandidateOk;

            //await candidatesBusiness.Delete(can.CandidateId);
            //await candidatesBusiness.Insert(can);
            //can.Dni = "00000000";
            //await candidatesBusiness.Replace(can, can.UserId);
            //await candidatesBusiness.Replace(can, can.UserId);
            //can.Dni = "00000001";
            //await candidatesBusiness.Replace(can, can.UserId);
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