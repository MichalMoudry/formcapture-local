using System.Text.Json;
using FormCaptureLocalWasm.Models.DbModels;
using Microsoft.JSInterop;

namespace FormCaptureLocalWasm.Services;

public class TesseractService : IRecognitionService
{
    /// <summary>
    /// Field for JSRuntime class instance.
    /// </summary>
    private readonly IJSRuntime _jSRuntime;

    public TesseractService(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

    public Task<List<string[]>> MultifieldRecognition(List<Field> fields, List<ProcessedFile> files, List<string> contentTypes, string locale)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> SinglefieldRecognition(Field field, byte[] content, string contentType, string locale)
    {
        var res = await _jSRuntime.InvokeAsync<JsonElement>("recogSingleField", field, Convert.ToBase64String(content), locale, contentType);
        return res[0].GetString().Split("/")[0];
    }

    public Task<List<string[]>> SingleFileMultipleFieldsRecognition(List<Field> fields, byte[] content, string locale, string contentType)
    {
        throw new NotImplementedException();
    }
}
