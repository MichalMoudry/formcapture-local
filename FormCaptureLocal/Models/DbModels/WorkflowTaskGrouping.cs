using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    /// <summary>
    /// Represents a grouping of <see cref="Workflow"/> instance and <see cref="WorkflowTask"/> instance.
    /// </summary>
    public class WorkflowTaskGrouping : Entity
    {
        /// <summary>
        /// Number indicating when task will be executed.
        /// </summary>
        public int ExecutionOrderNumber { get; set; }

        /// <summary>
        /// Name of the task group. Ex.: scan, identification, recognition, verification, export.
        /// </summary>
        public string TaskGroupName { get; set; }

        /// <summary>
        /// ID of the workflow task.
        /// </summary>
        public string TaskID { get; set; }

        /// <summary>
        /// ID of the workflow.
        /// </summary>
        public string WorkflowID { get; set; }
    }
}