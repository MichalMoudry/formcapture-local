using FormCaptureLocal.Models.Util;

namespace FormCaptureLocal.Models.DbModels
{
    public class Template : Model
    {
        public string ContentType { get; set; }

        public byte[] Image { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// ID of the user that created a specific instance.
        /// </summary>
        public string UserID { get; set; }

        public int Xdimension { get; set; }

        public int Ydimension { get; set; }
    }
}