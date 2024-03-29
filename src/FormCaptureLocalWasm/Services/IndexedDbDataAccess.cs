﻿using Microsoft.JSInterop;

namespace FormCaptureLocalWasm.Services;

/// <summary>
/// Service class for accessing browser indexed Db.
/// </summary>
public class IndexedDbDataAccess : IDataAccess
{
    /// <summary>
    /// Field for JSRuntime class instance.
    /// </summary>
    private readonly IJSRuntime _jSRuntime;

    public IndexedDbDataAccess(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

    public async Task<bool> AddItemAsync<T>(T entity, string tableName) => await _jSRuntime.InvokeAsync<bool>("addItem", entity, tableName);

    public async Task<bool> DeleteItemAsync(int id, string tableName) => await _jSRuntime.InvokeAsync<bool>("deleteItem", id, tableName);

    public async Task<T> GetItemAsync<T>(int id, string tableName) => await _jSRuntime.InvokeAsync<T>("getItem", id, tableName);

    public async Task<List<T>> GetItemsAsListAsync<T>(string tableName) => await _jSRuntime.InvokeAsync<List<T>>("getAllItems", tableName);

    public async Task<bool> UpdateItemAsync<T>(T entity, string tableName) => await _jSRuntime.InvokeAsync<bool>("putItem", entity, tableName);
}
