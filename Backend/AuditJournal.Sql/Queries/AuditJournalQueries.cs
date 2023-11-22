using System.Diagnostics.CodeAnalysis;

namespace BAS.AuditJournal.Sql.Queries
{
    /// <summary>
    /// Sql queries used by the API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AuditJournalQueries
    {
        /// <summary>
        /// Create view to generated account payment seats
        /// </summary>
        public static string GetAuditJournal => "dbo.spGetPaymentAccountJournal";
    }
}