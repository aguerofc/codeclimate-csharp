namespace BAS.AuditJournal.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all information
        /// </summary>
        /// <returns>List of T class</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Get element by code
        /// </summary>
        /// <param name="id">Identificator id</param>
        /// <returns>Object of T class</returns>
        Task<T> GetByIdAsync(long id);
        
        /// <summary>
        /// Add entity to repository
        /// </summary>
        /// <param name="entity">Entity for updated</param>
        /// <returns>Result message of the process</returns>
        Task<string> AddAsync(T entity);

        /// <summary>
        /// Update data to repository
        /// </summary>
        /// <param name="entity">Entity to upade</param>
        /// <returns>Result message of the process</returns>
        Task<string> UpdateAsync(T entity);

        /// <summary>
        /// Delete information by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result message of the process</returns>
        Task<string> DeleteAsync(long id);
    }
}
