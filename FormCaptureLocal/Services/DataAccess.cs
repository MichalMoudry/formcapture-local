using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormCaptureLocal.Services
{
    /// <summary>
    /// Service for accessing data.
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Field for JSRuntime class instance.
        /// </summary>
        private readonly IJSRuntime _jSRuntime;

        public DataAccess(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

        /// <summary>
        /// Method for obtaining instance of a specified class.
        /// </summary>
        /// <param name="id">ID of an entity.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>Instance of a specified class.</returns>
        public async Task<T> GetItem<T>(string id, string tableName) => await _jSRuntime.InvokeAsync<T>("getItem", id, tableName);

        /// <summary>
        /// Method for obtaining list of instances of a specified class.
        /// </summary>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>List of instances of a specified class.</returns>
        public async Task<List<T>> GetItemsAsList<T>(string tableName) => await _jSRuntime.InvokeAsync<List<T>>("getAllItems", tableName);

        /// <summary>
        /// Method for updating item in a database.
        /// </summary>
        /// <param name="entity">Entity with new data.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if update was successful, false if not.</returns>
        public async Task<bool> UpdateItem(object entity, string tableName) => await _jSRuntime.InvokeAsync<bool>("putItem", entity, tableName);

        /// <summary>
        /// Method for deleting item from a database.
        /// </summary>
        /// <param name="id">ID of an entity.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if delete was successful, false if not.</returns>
        public async Task<bool> DeleteItem(string id, string tableName) => await _jSRuntime.InvokeAsync<bool>("deleteItem", id, tableName);

        /// <summary>
        /// Method for adding item to a database.
        /// </summary>
        /// <param name="entity">Entity with data.</param>
        /// <param name="tableName">Name of the database table.</param>
        /// <returns>True if addition was successful, false if not.</returns>
        public async Task<bool> AddItem(object entity, string tableName) => await _jSRuntime.InvokeAsync<bool>("addItem", entity, tableName);
    }
}