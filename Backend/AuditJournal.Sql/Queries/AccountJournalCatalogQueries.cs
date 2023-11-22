using System.Diagnostics.CodeAnalysis;

namespace BAS.AuditJournal.Sql.Queries
{
    /// <summary>
    /// Sql queries used by the API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AccountJournalCatalogQueries
    {
        /// <summary>
        /// Get list of account seats
        /// </summary>
        public static string GetAccountJournalCatalog => "SELECT ID, Reference FROM dbo.tbAccountJournalCatalog UNION SELECT 0, 'Todos'";
    }
}
