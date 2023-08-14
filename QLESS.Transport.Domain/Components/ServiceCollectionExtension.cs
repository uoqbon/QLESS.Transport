using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLESS.Transport.Data.Automapper;
using QLESS.Transport.Data.Contracts;
using QLESS.Transport.Data.Contracts.Repositories;
using QLESS.Transport.Data.Repositories;

namespace QLESS.Transport.Data.Components
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, string connectionString)
        {
            var config = new MapperConfiguration(cfg => 
                cfg.AddProfile(new DomainProfile())).CreateMapper();

            services.AddSingleton(config);           
            services.AddDbContext<IQLESSTransportContext, QLESSTransportContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardTypeRepository, CardTypeRepository>();
            services.AddScoped<ICommuteHistoryRepository, CommuteHistoryRepository>();

            return services;
        }
    }
}
