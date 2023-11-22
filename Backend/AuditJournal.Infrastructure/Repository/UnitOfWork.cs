using BAS.AuditJournal.Application.Interfaces;

namespace BAS.AuditJournal.Infrastructure.Repository
{
    /// <summary>
    /// Unit of work pattern implementation
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Account repository
        /// </summary>
        public IAccountJournalRepository AuditJournals { get; set; }

        /// <summary>
        /// Seat catalog repository
        /// </summary>
        public ISeatCatalogRepository SeatCatalogs { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountJournalRepository">Account journal interface</param>
        /// <param name="seatCatalogRepository">Seat catalog interface</param>
        public UnitOfWork(IAccountJournalRepository accountJournalRepository, 
            ISeatCatalogRepository seatCatalogRepository)
        {
            AuditJournals = accountJournalRepository;
            SeatCatalogs = seatCatalogRepository;
        }

        
    }
}
