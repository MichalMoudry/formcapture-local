using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class Template : Model
    {
        public byte[] Image { get; set; }

        public string Name { get; set; }

        public int Xdimension { get; set; }

        public int Ydimension { get; set; }
    }
}