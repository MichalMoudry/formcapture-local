using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class Field : Model
    {
        public string ExpectedValue { get; set; }

        public int Height { get; set; }

        public bool IsIdentifying { get; set; }

        public string Name { get; set; }

        public string TemplateID { get; set; }

        public int Width { get; set; }

        public int Xposition { get; set; }

        public int Yposition { get; set; }
    }
}