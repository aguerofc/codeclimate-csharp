using BAS.AuditJournal.Entities;

namespace BAS.AuditJournal.Application.Interfaces
{
    /// <summary>
    /// Account journal repository interace
    /// </summary>
    public interface IAccountJournalRepository : IRepository<AccountJournal>
    {
        Task<IReadOnlyList<AccountJournal>> GetAccountJournal(int seatId, DateTime fromDate, DateTime toDate);
    }
}
