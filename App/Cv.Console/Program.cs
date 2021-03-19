using Cv.Business.Interface;
using Cv.Ioc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Cv.Models.Mock;

namespace Cv.AppConsole
{
    public class Program
    {
        private readonly ICountriesBusiness countriesBusiness;
        private readonly ICandidatesBusiness candidatesBusiness;
        private readonly IClientsBusiness clientsBusiness;
        private readonly IStatesBusiness statesBusiness;
        public Program(
            ICountriesBusiness countriesBusiness,
            ICandidatesBusiness candidatesBusiness,
            IStatesBusiness statesBusiness,
            IClientsBusiness clientsBusiness)
        {
            this.countriesBusiness = countriesBusiness;
            this.candidatesBusiness = candidatesBusiness;
            this.statesBusiness = statesBusiness;
            this.clientsBusiness = clientsBusiness;
        }

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.Services.GetRequiredService<Program>().Run();
        }

        public async Task Run()
        {

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