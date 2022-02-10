namespace FormCaptureLocalWasm.Models.DbModels
{
    /// <summary>
    /// Represents a field created on a document template.
    /// </summary>
    public class Field : Entity
    {
        /// <summary>
        /// Expected value of a field. Only used if field is used for document identification.
        /// </summary>
        public string? ExpectedValue { get; set; }

        /// <summary>
        /// Height of the field (in px).
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Identfier if field is used for document identification.
        /// </summary>
        public bool IsIdentifying { get; set; }

        /// <summary>
        /// Name of the field.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ID of the template that a field is connected to.
        /// </summary>
        public string? TemplateID { get; set; }

        /// <summary>
        /// ID of the user that created a specific instance.
        /// </summary>
        public string? UserID { get; set; }

        /// <summary>
        /// Width of the field (in px).
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// X position of the field on a specific document template.
        /// </summary>
        public int Xposition { get; private set; }

        /// <summary>
        /// Y position of the field on a specific document template.
        /// </summary>
        public int Yposition { get; private set; }

        /// <summary>
        /// Method for setting width and height of a field.
        /// </summary>
        /// <param name="width">Width of the field.</param>
        /// <param name="height">Height of the field.</param>
        public void SetDimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Method for setting position of a field.
        /// </summary>
        /// <param name="x">Value on the x-axis of the template image.</param>
        /// <param name="y">Value on the y-axis of the template image.</param>
        public void SetPosition(int x, int y)
        {
            Xposition = x;
            Yposition = y;
        }
    }
}