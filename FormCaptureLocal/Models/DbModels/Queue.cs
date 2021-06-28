using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Queue class represents queue of processed batches.
    /// </summary>
    public class Queue : Model
    {
        /// <summary>
        /// Name of the queue for easier identification by the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Optional ID of the workflow.
        /// </summary>
        public string WorkflowID { get; set; }
    }
}