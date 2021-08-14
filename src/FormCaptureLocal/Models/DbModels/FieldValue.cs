using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Represents a recognized value on a single processed document.
    /// </summary>
    public class FieldValue : Entity
    {
        /// <summary>
        /// ID of the field that this value is connected to.
        /// </summary>
        public string FieldID { get; set; }

        /// <summary>
        /// Name of the field, that this value is connected to.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// ID of the file that this value is recognized on.
        /// </summary>
        public string FileID { get; set; }

        /// <summary>
        /// Recognized value.
        /// </summary>
        public string Value { get; set; }
    }
}