using BAS.AuditJournal.Application.Interfaces;
using BAS.AuditJournal.Entities;
using BAS.AuditJournal.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BAS.AuditJournal.Infrastructure.Repository
{
    public class AccountJournalRepository : IAccountJournalRepository
    {
        #region Private Members 

        private readonly IConfiguration configuration;

        #endregion

        #region Constructor 

        public AccountJournalRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Journal repository custom methods 

        /// <summary>
        /// Get audit account records
        /// </summary>
        /// <param name="seatId">Account seat code</param>
        /// <param name="fromDate">Init date</param>
        /// <param name="toDate">End Date</param>
        /// <returns>Account journal object</returns>
        public async Task<IReadOnlyList<AccountJournal>> GetAccountJournal(int seatId, DateTime fromDate, DateTime toDate)
        {

            using (var connection = new SqlConnection(Utils.Helpers.GetConnectionString()))
            {
                await connection.OpenAsync();
                var parameters = new DynamicParameters();

                parameters.Add("@BeginDate", fromDate, dbType: DbType.DateTime);
                parameters.Add("@EndDate", toDate, dbType: DbType.DateTime);
                parameters.Add("@SeatId", seatId, dbType: DbType.Int16);
                var result = await connection.QueryAsync<AccountJournal>(AuditJournalQueries.GetAuditJournal, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        #endregion

        #region Inherited methods

        async Task<string> IRepository<AccountJournal>.AddAsync(AccountJournal entity)
        {
            throw new NotImplementedException();
        }

        async Task<string> IRepository<AccountJournal>.DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        async Task<IReadOnlyList<AccountJournal>> IRepository<AccountJournal>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        async Task<AccountJournal> IRepository<AccountJournal>.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        async Task<string> IRepository<AccountJournal>.UpdateAsync(AccountJournal entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}