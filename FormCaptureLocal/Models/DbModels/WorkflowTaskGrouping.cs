using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class WorkflowTaskGrouping : Model
    {
        public int ExecutionOrderNumber { get; set; }

        public string TaskGroupName { get; set; }

        public string TaskID { get; set; }

        public string WorkflowID { get; set; }
    }
}