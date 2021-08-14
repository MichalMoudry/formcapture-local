using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Class that represents a single file that is processed by the system.
    /// </summary>
    public class ProcessedFile : Entity
    {
        /// <summary>
        /// Content of the file, but converted to black and white for better recognition results.
        /// </summary>
        public byte[] BlackAndWhiteContent { get; set; }

        /// <summary>
        /// Content of the file.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// String value indicating type of the uploaded content.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Name of the processed file. Ex.: File.pdf
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the queue that this file belongs to.
        /// </summary>
        public string QueueID { get; set; }

        /// <summary>
        /// ID of the template that this file belongs to.
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// File type of the processed file.
        /// </summary>
        public string Type { get; set; }
    }
}