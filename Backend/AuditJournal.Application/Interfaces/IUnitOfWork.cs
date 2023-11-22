namespace BAS.AuditJournal.Application.Interfaces
{
    public interface IUnitOfWork 
    {
        IAccountJournalRepository AuditJournals { get; }
        ISeatCatalogRepository SeatCatalogs { get; }

    }
}
