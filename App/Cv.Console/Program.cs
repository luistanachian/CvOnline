using Cv.Business.Interface;
using Cv.Ioc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

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
            //aca va todo lo que se necesita ejecutar

            var countries = countriesBusiness.GetAll();
            var states = statesBusiness.GetAllByCountryId(1);
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