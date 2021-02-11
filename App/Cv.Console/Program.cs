using Cv.Business.Interface;
using Cv.Ioc;
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
            TestCountries();
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
    }
}
