using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Represents a workflow that can be executed during each step of document processing.
    /// </summary>
    public class Workflow : Entity
    {
        /// <summary>
        /// Name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the user that created a specific instance.
        /// </summary>
        public string UserID { get; set; }
    }
}