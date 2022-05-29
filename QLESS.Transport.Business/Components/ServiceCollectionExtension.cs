using Microsoft.Extensions.DependencyInjection;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Business.Managers;
using QLESS.Transport.Business.Services;
using QLESS.Transport.Domain.Components;

namespace QLESS.Transport.Business.Components
{
    public static class ServiceCollectionExtension
    {        
        public static IServiceCollection AddBusiness(this IServiceCollection services, string connectionString)
        {
            services.AddDomain(connectionString);

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardTypeService, CardTypeService>();
            services.AddScoped<ICommuteHistoryService, CommuteHistoryService>();
            services.AddScoped<ICardTransactionManager, CardTransactionManager>();
            services.AddScoped<ICommuteManager, CommuteManager>();

            return services;
        }        
    }
}
