using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLESS.Transport.Domain.Automapper;
using QLESS.Transport.Domain.Contracts;
using QLESS.Transport.Domain.Contracts.Repositories;
using QLESS.Transport.Domain.Repositories;

namespace QLESS.Transport.Domain.Components
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
