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
using Cv.Models.Models;
using System.Threading.Tasks;

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

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public void Run()
        {
            ImportarPaises();
            ImportarEstados();
        }
        public void ImportarPaises()
        {
            var Client = new MongoClient(ConfigMongoDb.ConectionString);
            var db = Client.GetDatabase(ConfigMongoDb.BD_CvOnline);

            var Countries = db.GetCollection<CountryModel>("Countries").Find(c => true).ToList();


            var CountriesNew = db.GetCollection<pCountryModel>("Countries2");
            CountriesNew.DeleteMany(e => true);

            var lista = new List<pCountryModel>();
            foreach (var country in Countries)
            {
                lista.Add(new pCountryModel
                {
                    id = country.id,
                    code = country.iso2,
                    currency = country.currency,
                    currency_symbol = country.currency_symbol,
                    name = country.name,
                    phone_code = country.phone_code
                });
            }
            CountriesNew.InsertMany(lista);
        }

        public void ImportarEstados()
        {
            var Client = new MongoClient(ConfigMongoDb.ConectionString);
            var db = Client.GetDatabase(ConfigMongoDb.BD_CvOnline);
            var states = db.GetCollection<StateModel>("States").Find(c => true).ToList();
            var statesNew = db.GetCollection<pStateModel>("States2");
            statesNew.DeleteMany(e => true);

            var lista = new List<pStateModel>();
            foreach (var state in states)
            {
                lista.Add(new pStateModel
                {
                    id = state.id,
                    country_id = state.country_id,
                    name = state.name
                });
            }
            statesNew.InsertMany(lista);
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