using FormCaptureLocalWasm.Models.DbModels;

namespace FormCaptureLocalWasm.Services;

/// <summary>
/// Interface for recognition services.
/// </summary>
public interface IRecognitionService
{
    /// <summary>
    /// Method for executing multifield recognition on multiple files.
    /// </summary>
    /// <param name="fields">List of fields that will be used during recognition.</param>
    /// <param name="files">Files that will be used during recognition.</param>
    /// <param name="locale">Locale of recognition.</param>
    /// <param name="contentTypes">Content type of processed file. Indexes need to correspond to processed files list.</param>
    /// <returns>List of string arrays that contain recognition result. Format: [0] => actual result, [1] => ID of the field, [2] => file index.</returns>
    Task<List<string[]>> MultifieldRecognition(List<Field> fields, List<ProcessedFile> files, List<string> contentTypes, string locale);

    /// <summary>
    /// Method for single field recognition on single file.
    /// </summary>
    /// <param name="field">Field that will be used during recognition.</param>
    /// <param name="content">Content that will be used during recognition.</param>
    /// <param name="locale">Locale of recognition.</param>
    /// <param name="contentType">Content type of inserted content.</param>
    /// <returns>Json element with recognition result.</returns>
    Task<string?> SinglefieldRecognition(Field field, byte[] content, string contentType, string locale);

    /// <summary>
    /// Method for executing recognition on single file and with multiple fields.
    /// </summary>
    /// <param name="fields">List of fields that will be used during recognition.</param>
    /// <param name="content">Content that will be used during recognition.</param>
    /// <param name="locale">Locale of recognition.</param>
    /// <param name="contentType">Content type of inserted content.</param>
    /// <returns>String arrays that contain recognition result.</returns>
    Task<List<string[]>> SingleFileMultipleFieldsRecognition(List<Field> fields, byte[] content, string locale, string contentType);
}
