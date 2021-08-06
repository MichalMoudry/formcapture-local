using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Represents a field created on a document template.
    /// </summary>
    public class Field : Entity
    {
        /// <summary>
        /// Expected value of a field. Only used if field is used for document identification.
        /// </summary>
        public string ExpectedValue { get; set; }

        /// <summary>
        /// Height of the field (in px).
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Identfier if field is used for document identification.
        /// </summary>
        public bool IsIdentifying { get; set; }

        /// <summary>
        /// Name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the template that a field is connected to.
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// Width of the field (in px).
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// X position of the field on a specific document template.
        /// </summary>
        public int Xposition { get; set; }

        /// <summary>
        /// Y position of the field on a specific document template.
        /// </summary>
        public int Yposition { get; set; }
    }
}