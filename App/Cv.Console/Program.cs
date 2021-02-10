using Cv.Business.Interface;
using Cv.Ioc;
using Cv.Models;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cv.AppConsole
{
    public class Program
    {
        private readonly ICountriesBusiness countriesBusiness;
        public Program(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public void Run()
        {
            countriesBusiness.Insert(new CountryModel { Code = "AR", Country = "Argentina" });
            countriesBusiness.Insert(new CountryModel { Code = "VE", Country = "Venezuela" });

            var list = countriesBusiness.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Code} - {item.Country}");
            }
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
