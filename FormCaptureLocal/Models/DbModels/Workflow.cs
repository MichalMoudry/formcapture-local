using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class Workflow : Model
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