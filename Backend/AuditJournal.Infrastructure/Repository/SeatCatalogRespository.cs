using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Entities;
using BAS.AuditJournal.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BAS.AuditJournal.Infrastructure.Repository
{
    /// <summary>
    /// Seat catalog repository
    /// </summary>
    public class SeatCatalogRespository : ISeatCatalogRepository
    {
        #region Private Members 

        private readonly IConfiguration configuration;

        #endregion

        #region Constructor 

        public SeatCatalogRespository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Seat catalog custom methods 
        #endregion

        #region Inherited methods
        async Task<string> IRepository<SeatCatalog>.AddAsync(SeatCatalog entity)
        {
            throw new NotImplementedException();
        }

        async Task<string> IRepository<SeatCatalog>.DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all seats in catalog
        /// </summary>
        /// <returns>List of account seats</returns>
        async Task<IReadOnlyList<SeatCatalog>> IRepository<SeatCatalog>.GetAllAsync()
        {
            using (var connection = new SqlConnection(Utils.Helpers.GetConnectionString()))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<SeatCatalog>(AccountJournalCatalogQueries.GetAccountJournalCatalog);
                return result.ToList();
            }
        }

         async Task<SeatCatalog> IRepository<SeatCatalog>.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

         async Task<string> IRepository<SeatCatalog>.UpdateAsync(SeatCatalog entity)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
