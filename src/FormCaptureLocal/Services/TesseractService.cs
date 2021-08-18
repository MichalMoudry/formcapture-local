using FormCaptureLocal.Models.DbModels;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FormCaptureLocal.Services
{
    /// <summary>
    /// Service for working with Tesseract.js library.
    /// </summary>
    public class TesseractService
    {
        /// <summary>
        /// Field for JSRuntime class instance.
        /// </summary>
        private readonly IJSRuntime _jSRuntime;

        public TesseractService(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

        /// <summary>
        /// Method for executing multifield recognition on multiple files.
        /// </summary>
        /// <param name="fields">List of fields that will be used during recognition.</param>
        /// <param name="files">Files that will be used during recognition.</param>
        /// <param name="locale">Locale of recognition.</param>
        /// <param name="contentTypes">Content type of processed file. Indexes need to correspond to processed files list.</param>
        /// <returns>List of string arrays that contain recognition result. Format: [0] => actual result, [1] => ID of the field, [2] => file index.</returns>
        public async Task<List<string[]>> MultifieldRecognition(List<Field> fields, List<ProcessedFile> files, string locale, List<string> contentTypes)
        {
            var response = await _jSRuntime.InvokeAsync<JsonElement>("recog", fields,
            files.Select(i => Convert.ToBase64String(i.BlackAndWhiteContent)),
            locale,
            contentTypes);
            var reponseList = response.EnumerateArray().ToList();
            var results = new List<string[]>();
            foreach (var listItem in reponseList)
            {
                results.Add(listItem.ToString().Split("/"));
            }
            return results;
        }

        /// <summary>
        /// Method for single field recognition on single file.
        /// </summary>
        /// <param name="field">Field that will be used during recognition.</param>
        /// <param name="content">Content that will be used during recognition.</param>
        /// <param name="locale">Locale of recognition.</param>
        /// <param name="contentType">Content type of inserted content.</param>
        /// <returns>Json element with recognition result.</returns>
        public async Task<JsonElement> SinglefieldRecognition(
            Field field,
            byte[] content,
            string locale,
            string contentType) => await _jSRuntime.InvokeAsync<JsonElement>("recogSingleField", field, Convert.ToBase64String(content), locale, contentType);

        /// <summary>
        /// Method for executing recognition on single file and with multiple fields.
        /// </summary>
        /// <param name="fields">List of fields that will be used during recognition.</param>
        /// <param name="content">Content that will be used during recognition.</param>
        /// <param name="locale">Locale of recognition.</param>
        /// <param name="contentType">Content type of inserted content.</param>
        /// <returns>String arrays that contain recognition result.</returns>
        public async Task<List<string[]>> SingleFileMultipleFieldsRecognition(List<Field> fields, byte[] content, string locale, string contentType)
        {
            var response = await _jSRuntime.InvokeAsync<JsonElement>("singleFileMultipleFieldsRecog", fields, Convert.ToBase64String(content), locale, contentType);
            var reponseList = response.EnumerateArray().ToList();
            var results = new List<string[]>();
            foreach (var listItem in reponseList)
            {
                results.Add(listItem.ToString().Split("/"));
            }
            return results;
        }
    }
}