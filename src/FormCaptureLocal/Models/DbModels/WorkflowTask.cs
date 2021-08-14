using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Class that represents a singular task within the system.
    /// </summary>
    public class WorkflowTask : Entity
    {
        /// <summary>
        /// Content of the task as base64.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the user that created a specific instance.
        /// </summary>
        public string UserID { get; set; }
    }
}