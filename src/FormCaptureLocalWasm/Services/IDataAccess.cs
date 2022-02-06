namespace FormCaptureLocalWasm.Services
{
    /// <summary>
    /// Interface for data access classes.
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Asynchronous method for adding item to a database.
        /// </summary>
        /// <param name="entity">Entity with data.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if addition was successful, false if not.</returns>
        Task<bool> AddItemAsync(object entity, string tableName);

        /// <summary>
        /// Asynchronous method for deleting item from a database.
        /// </summary>
        /// <param name="id">ID of an entity.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if delete was successful, false if not.</returns>
        Task<bool> DeleteItemAsync(string id, string tableName);

        /// <summary>
        /// Asynchronous method for obtaining instance of a specified class.
        /// </summary>
        /// <param name="id">ID of an entity.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>Instance of a specified class.</returns>
        Task<T> GetItemAsync<T>(string id, string tableName);

        /// <summary>
        /// Asynchronous method for obtaining list of instances of a specified class.
        /// </summary>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>List of instances of a specified class.</returns>
        Task<List<T>> GetItemsAsListAsync<T>(string tableName);

        /// <summary>
        /// Asynchronous method for updating item in a database.
        /// </summary>
        /// <param name="entity">Entity with new data.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if update was successful, false if not.</returns>
        Task<bool> UpdateItemAsync(object entity, string tableName);
    }
}
