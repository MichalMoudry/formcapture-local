using FormCaptureLocal.Models.Util;
using FormCaptureLocal.Models.Util.Enums;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Queue class represents queue of processed batches.
    /// </summary>
    public class Queue : Entity
    {
        /// <summary>
        /// Locale used for processing documents in a queue.
        /// </summary>
        public Locale Locale { get; set; }

        /// <summary>
        /// Name of the queue for easier identification by the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last task executed on a specific queue.
        /// </summary>
        public QueueTask QueueTask { get; set; }

        /// <summary>
        /// ID of the user that created a specific instance.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Optional ID of the workflow.
        /// </summary>
        public string WorkflowID { get; set; }

        /// <summary>
        /// Value indicating if queue is supposed to be processed automaticly or with user intervention.
        /// </summary>
        public bool IsAutomatic { get; set; }
    }
}