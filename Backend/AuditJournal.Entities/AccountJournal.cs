namespace BAS.AuditJournal.Entities
{
    /// <summary>
    /// Audit account journal entity
    /// </summary>
    /// 

    public class AccountJournal
    {
        /// <summary>
        /// Account number
        /// </summary>
        public string? AccountId { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        public string? AccountName { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        /// <remarks>DB = Debit account</remarks>
        /// <remarks>CR = Credit account</remarks>
        public string? AccountType { get; set; }

        /// <summary>
        /// Transaction amount balance
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Transaction amount balance
        /// </summary>
        public string? DocumentReference { get; set; }

        /// <summary>
        /// Seat account description
        /// </summary>
        public string? SeatName { get; set; }

        /// <summary>
        /// Comments for transaction account
        /// </summary>
        public string? Nit { get; set;}
    }
}