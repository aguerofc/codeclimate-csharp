using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BAS.AuditJournal.Infrastructure
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountJournalRepository, AccountJournalRepository>();
            services.AddTransient<ISeatCatalogRepository, SeatCatalogRespository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
