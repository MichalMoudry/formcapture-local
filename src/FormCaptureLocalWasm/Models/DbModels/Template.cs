namespace FormCaptureLocalWasm.Models.DbModels;

/// <summary>
/// Represents a template of a file that will be processed.
/// </summary>
public class Template : Entity
{
    /// <summary>
    /// Type of the uploaded content.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Image data as byte array.
    /// </summary>
    public byte[]? Image { get; set; }

    /// <summary>
    /// Name of the template.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// ID of the user that created a specific instance.
    /// </summary>
    public string UserID { get; set; }

    /// <summary>
    /// X dimension of the uploaded file.
    /// </summary>
    public int Xdimension { get; set; }

    /// <summary>
    /// Y dimension of the uploaded file.
    /// </summary>
    public int Ydimension { get; set; }
}