using Cv.Business.Class;
using Cv.Business.Interface;
using Cv.Dao.Class;
using Cv.Dao.Interface;
using Cv.Repository.Class;
using Cv.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Cv.Ioc
{
    public static class IocContainer
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddSingleton<ICountriesDao, CountriesDao>();
            services.AddSingleton<ICountriesRepository, CountriesRepository>();
            services.AddSingleton<ICountriesBusiness, CountriesBusiness>();

            services.AddSingleton<IStatesDao, StatesDao>();
            services.AddSingleton<IStatesRepository, StatesRepository>();
            services.AddSingleton<IStatesBusiness, StatesBusiness>();

            services.AddSingleton<ICandidatesDao, CandidatesDao>();
            services.AddSingleton<ICandidatesRepository, CandidatesRepository>();
            services.AddSingleton<ICandidatesBusiness, CandidatesBusiness>();
        }
    }
}