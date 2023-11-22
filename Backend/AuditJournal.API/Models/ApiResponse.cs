namespace BAS.AuditJournal.Models
{
    /// <summary>
    /// Api response standard class
    /// </summary>
    /// <typeparam name="T">Object send to response</typeparam>
    public class ApiResponse<T>
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
        
}
