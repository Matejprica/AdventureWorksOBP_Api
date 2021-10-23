using AdventureWorksOBP.Data.DataModels;
using AdventureWorksOBP.Data.Interfaces;
using AdventureWorksOBP.Data.Models;
using AdventureWorksOBP.Services.Interfaces;
using AdventureWorksOBP.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventueWorksOBP_API.Extensions
{
    public static class ConfigureContainerExtension
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, string dataConnectionString = null, string authConnectionString = null)
        {
            serviceCollection.AddDbContext<AdventureWorksOBPContext>(options =>
                options.UseSqlServer(dataConnectionString ?? GetDataConnectionStringFromConfig()));
        }

        public static void AddRepository(this IServiceCollection serviceColletion)
            => serviceColletion.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));

        private static string GetDataConnectionStringFromConfig()
            => new DataDatabaseConfiguration().GetDataConnectionString();

        public static void AddTransientServices(this IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IKupacService, KupacService>();
            serviceColletion.AddTransient<IGradService, GradService>();
        }
    }
}
