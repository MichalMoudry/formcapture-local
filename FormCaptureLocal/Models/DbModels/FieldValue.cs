using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class FieldValue : Model
    {
        public string FieldID { get; set; }

        public string FieldName { get; set; }

        public string FileID { get; set; }

        public string Value { get; set; }
    }
}